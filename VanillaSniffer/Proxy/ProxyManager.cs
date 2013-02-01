using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using VanillaSniffer.Packet;

namespace VanillaSniffer.Proxy
{
    internal class ProxyManager
    {
        private Socket client, server;
        private ProxyForwarder clientToServerThread;
        private ProxyForwarder serverToClientThread;

        public ProxyManager()
        {
            Console.WriteLine("<<< Connecting... >>>");
            client = ListenForClient();
            TcpClient serverConnect = new TcpClient("vanillafeenix.servegame.org", 3724);
            server = serverConnect.Client;
            clientToServerThread = new ProxyForwarder(client, server, "Client to Server");
            serverToClientThread = new ProxyForwarder(server, client, "Server to Client");
            Console.WriteLine("<<< Connected! >>>");
        }

        private Socket ListenForClient()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 3724);
            listener.Start();
            Socket socket = listener.AcceptSocket(); //Blocks code
            return (socket);
        }

        public void disconnect()
        {
            try
            {
                if (client != null)
                    client.Close();
                if (server != null)
                    server.Close();
            }
            catch (IOException e)
            {
                Console.Write(e);
            }

        }
    }
}