using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using VanillaSniffer.Packet;

namespace VanillaSniffer.Proxy
{
    public class ProxyManager
    {
        public static Socket RemoteServer;
        public static List<ProxyForwarder> clientToServerThreads = new List<ProxyForwarder>();
        public static List<ProxyForwarder> serverToClientThreads = new List<ProxyForwarder>();

        public ProxyManager()
        {

            //We need to listen for clients
            Server server = new Server();

            Console.WriteLine("<<< Connecting to remote server... >>>");
            //Connect to remove server
            TcpClient serverConnect = new TcpClient("vanillafeenix.servegame.org", 3724);
            RemoteServer = serverConnect.Client;
            Console.WriteLine("<<< Connected to remote server! >>>");

            Update();
        }

        private void Update()
        {
            while (true)
            {
                Thread.Sleep(10);

                foreach (ProxyForwarder clientThread in clientToServerThreads)
                {
                    if (clientThread != null) clientThread.OnDataRecived += (packet) => ClientPacket(packet);
                }

                foreach (ProxyForwarder serverThread in serverToClientThreads)
                {
                    if (serverThread != null) serverThread.OnDataRecived +=(packet) => ServerPacket(packet);
                }
            }
        }

        private void ServerPacket(Byte[] packet)
        {
            Console.WriteLine("Server -> Client " + (PacketHeaders) packet[0]);
            if ((PacketHeaders) (byte) packet[0] == PacketHeaders.CMD_REALM_LIST)
            {
                PacketReader.ReadRealms(packet);
                packet = PacketWriter.WriteRealm(packet);
            }
        }
        
        private void ClientPacket(Byte[] packet)
        {
            Console.WriteLine("Client -> Server " + (PacketHeaders) packet[0]);
            if ((PacketHeaders) (byte) packet[0] == PacketHeaders.CMD_REALM_LIST)
            {
                PacketReader.ReadRealms(packet);
                packet = PacketWriter.WriteRealm(packet);
            }
        }
        
    }
}