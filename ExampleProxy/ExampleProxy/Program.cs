using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace ExampleProxy
{
    public enum ClientProxyType
    {
        Server, // WoW connects to this local server
        Client // Connects to private server
    }

    public class Program
    {
        public static string SERVER_IP = "vanillafeenix.servegame.org";

        static void Main(string[] args)
        {
            TcpListener listner = new TcpListener(IPAddress.Any, 3724);
            listner.Start();

            while (true)
            {
                // Blocking on main thread.
                TcpClient proxyServer = listner.AcceptTcpClient(); // User is someone who connects to 127.0.0.1
                Console.WriteLine("WoW Client Connected.");

                TcpClient proxyClient = new TcpClient(SERVER_IP, 3724);
                Console.WriteLine("Connected to private server.");

                ProxyConnection proxyConnectionServer = new ProxyConnection(ClientProxyType.Server, proxyServer);
                ProxyConnection proxyConnectionClient = new ProxyConnection(ClientProxyType.Client, proxyClient);

                // This bridge just connects the two connections.
                //CreateBasicBridge(proxyConnectionServer, proxyConnectionClient);

                // This traces the packer headers out
                //CreateWoWTraceHeaders(proxyConnectionServer, proxyConnectionClient);

                WoWPacketListener wowPacketDetour = new WoWPacketListener(proxyConnectionServer, proxyConnectionClient);

                wowPacketDetour.AddDetour(RealmPacketHeaders.CMD_REALM_LIST, (direction, data) =>
                {
                    if (direction == Direction.Server2Client)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (BinaryWriter bw = new BinaryWriter(ms))
                            {
                                // bw.Write((byte)0x10); // cmd
                                // bw.Write((Int16)0); // size
                                bw.Write((UInt32)0x0000); // Ender?
                                bw.Write((byte)1); // Realm count

                                for (int i = 0; i < 1; i++)
                                {


                                    bw.Write((UInt32)1); // Icon
                                    bw.Write((byte)0); // Flag

                                    WriteCString(bw, "Proxy " + i);
                                    WriteCString(bw, "127.0.0.1:8998");

                                    bw.Write((float)1); // Pop
                                    bw.Write((byte)3); // Chars
                                    bw.Write((byte)1); // time
                                    bw.Write((byte)0); // time

                                }
                                bw.Write((UInt16)0x0002);
                            }

                            byte[] array = ms.ToArray();
                            byte[] header = new byte[1] { (byte)RealmPacketHeaders.CMD_REALM_LIST };

                            MemoryStream lengthstream = new MemoryStream();
                            BinaryWriter length = new BinaryWriter(lengthstream);
                            length.Write((short)array.Length);

                            
                            data = Concat(Concat(header, lengthstream.ToArray()), array);

                            proxyConnectionServer.Send(data);
                            Console.WriteLine("Sent replaced realmlist");
                        }

                        // This stops the original packet
                        return false;
                    }

                    return true;
 
                });

            }

        }

        static void WriteCString(BinaryWriter bw, string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input + '\0');
            bw.Write(data);
        }

        static byte[] Concat(byte[] a, byte[] b)
        {
            var res = new byte[a.Length + b.Length];
            for (int t = 0; t < a.Length; t++)
            {
                res[t] = a[t];
            }
            for (int t = 0; t < b.Length; t++)
            {
                res[t + a.Length] = b[t];
            }
            return res;
        }

        static void CreateBasicBridge(ProxyConnection server, ProxyConnection client)
        {
            server.OnDataRecived += (data) => client.Send(data); // Sends Server -> Client packets
            client.OnDataRecived += (data) => server.Send(data); // Sends Client -> Server packets
        }

        static void CreateWoWTraceHeaders(ProxyConnection server, ProxyConnection client)
        {
            // First byte is opcode
            server.OnDataRecived += (data) => Console.WriteLine("Client -> Server " + (RealmPacketHeaders)data[0]); 
            client.OnDataRecived += (data) => Console.WriteLine("Client <- Server " + (RealmPacketHeaders)data[0]);
        }
    }

    public delegate void DataRecived(byte[] data);

    public class ProxyConnection
    {
        public ClientProxyType Type { get; private set; }
        public TcpClient Client { get; private set; }
        public NetworkStream Stream { get; private set; }
        public Thread Thread { get; private set; }

        public event DataRecived OnDataRecived;

        public ProxyConnection(ClientProxyType type, TcpClient client)
        {
            Type = type;
            Client = client;
            Stream = client.GetStream();

            Thread = new Thread(new ThreadStart(Update)) { Name = type.ToString() };
            Thread.Start();
        }

        // Runs on a seperate thread
        private void Update()
        {
            // Setup a 2kb byte array for packets
            Byte[] buffer = new byte[2048];

            while (true)
            {
                // Pause this thread for 10ms
                Thread.Sleep(10);

                // Wait untill we have data
                if (Client.Available > 0)
                {
                    // Grabs the packet, places it into data and returns its size
                    int packetSize = Stream.Read(buffer, 0, Client.Available);

                    // We create a new array witch is exactly the size of the packet
                    byte[] actualPacket = new byte[packetSize];

                    // Copy the contents from the buffer, to our actualPacket.. nice and neat
                    Array.Copy(buffer, actualPacket, packetSize);
                    
                    // Dispatch OnDataRecived to listeners
                    if (OnDataRecived != null) OnDataRecived(actualPacket);
                }
            }
        }

        public void Send(byte[] data)
        {
            Stream.Write(data, 0, data.Length);
        }
    }
}
