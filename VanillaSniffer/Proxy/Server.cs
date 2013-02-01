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
            Console.WriteLine("<<< Server Initialised on port: " + port + " >>>");
            listener = new TcpListener(IPAddress.Any, _port);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();
        }

        private void ListenForClients()
        {
            listener.Start();
            try
            {
                while(true)
                {
                    Socket client = listener.AcceptSocket();
                    Connect(client);
                }
            }
            catch (Exception e)
            {
            Console.WriteLine("\nMain Exception raised!");
            Console.WriteLine("Source :{0} ", e.Source);
            Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        private void Connect(Socket client)
        {
            Console.WriteLine("<<< Client Connection from "+client.RemoteEndPoint.ToString()+" >>>");
            ProxyForwarder clientToServer = new ProxyForwarder(client, ProxyManager.RemoteServer, "clientToServer");
            ProxyForwarder serverToClient = new ProxyForwarder(ProxyManager.RemoteServer, client, "serverToClient");
            ProxyManager.clientToServerThreads.Add(clientToServer);
            ProxyManager.serverToClientThreads.Add(serverToClient);
        }
    }
}
