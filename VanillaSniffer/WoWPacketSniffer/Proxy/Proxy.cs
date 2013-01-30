using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaSniffer.Proxy
{
    class Proxy
    {
        public Proxy()
        {
            Server server = new Server();
            Client client = new Client();

            client.clientStream.Write(server.packets[0]);

            Console.WriteLine("Proxy Started");
        }
    }
}
