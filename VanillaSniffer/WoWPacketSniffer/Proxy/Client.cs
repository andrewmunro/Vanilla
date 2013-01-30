using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace VanillaSniffer.Proxy
{
    class Client
    {
        public NetworkStream clientStream;

        public Client(IPAddress ip = IPAddress.parse("127.0.0.1"), int port = 3000)
        {
            TcpClient client = new TcpClient();
            serverEndPoint = new IPEndPoint(ip, port);
            client.Connect(serverEndPoint);
            clientStream = client.GetStream();
        }
    }
}
