using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using VanillaSniffer.Packet;

namespace VanillaSniffer.Proxy
{
    class Client
    {
        private Thread _Thread;
        public TcpClient _ListenSocket;
        public NetworkStream _SendingNetworkStream;
        public NetworkStream _ListenNetworkStream;

        public Client(String _ip = "127.0.0.1", int _port = 3724)
        {
            TcpClient socket = new TcpClient(_ip, _port);
            NetworkStream networkStream = socket.GetStream();
            Console.WriteLine("<<< Client connection initialised: "+_ip+" >>>");
            Console.Read();
        }
    }
}
