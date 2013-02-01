using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace VanillaSniffer.Proxy
{
    class Server
    {     
        private TcpListener listener;
        private int port;
        private Thread listenThread;
        public List<byte[]> packets = new List<byte[]>();

        public Server(int _port = 3724)
        {
            port = _port;
            listener = new TcpListener(IPAddress.Any, _port);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }

        private void ListenForClients()
        {
            listener.Start();
            try
            {
                while(true)
                {
                    Console.WriteLine("<<< Server Initialised on port: "+port+" >>>");
                    TcpClient client = listener.AcceptTcpClient();
                    Thread clientThread = new Thread(new ParameterizedThreadStart(Communicate));
                    clientThread.Start(client);

                }
            }
            catch (Exception e)
            {
            Console.WriteLine("\nMain Exception raised!");
            Console.WriteLine("Source :{0} ", e.Source);
            Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        private void Communicate(object tcpclient)
        {
            TcpClient client = (TcpClient) tcpclient;
            NetworkStream clientStream = client.GetStream();

            byte[] packet = new byte[2048];
            int bytesRead;
            while (true)
            {
                bytesRead = 0;
                try
                {
                    bytesRead = clientStream.Read(packet, 0, 2048);
                }
                catch
                {
                  //a socket error has occured
                  break;
                }
                if (bytesRead == 0)
                {
                  //the client has disconnected from the server
                  break;
                }
                ASCIIEncoding encoder = new ASCIIEncoding();
                Console.WriteLine(encoder.GetString(packet, 0, bytesRead));
                Console.Read();
                packets.Add(packet);
            }
            client.Close();
        }
    }
}
