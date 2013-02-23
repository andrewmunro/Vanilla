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
        public static List<Proxy> proxyList = new List<Proxy>(); 
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

        }

        public static void AddProxy(Proxy proxy)
        {
            proxyList.Add(proxy);
        }
        
    }
}