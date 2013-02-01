using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using VanillaSniffer.Packet;

namespace VanillaSniffer.Proxy
{
    internal class ProxyManager
    {
        public static Socket RemoteServer;
        public static List<ProxyForwarder> clientToServerThreads = new List<ProxyForwarder>();
        public static List<ProxyForwarder> serverToClientThreads = new List<ProxyForwarder>();

        public ProxyManager()
        {
            Console.WriteLine("<<< Connecting to remote server... >>>");

            //Connect to remove server
            TcpClient serverConnect = new TcpClient("vanillafeenix.servegame.org", 3724);
            RemoteServer = serverConnect.Client;
            Console.WriteLine("<<< Connected to remote server! >>>");

            //We need to listen for clients
            Server server = new Server();
        }
    }
}