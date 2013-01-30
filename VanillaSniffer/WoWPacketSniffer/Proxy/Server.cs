using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VanillaSniffer.Proxy
{
    class Server()
    {     
        private TcpListener listener;
        private Thread listenThread;
        public Array packets = new Array();

        public Server(IPAddress ip = IPAddress.Any, int port = 3000)
        {
            listener = new TcpListener(ip, port);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }

        private void ListenForClients()
        {
            listener.Start();
            try
            {
                while(listener)
                {
                    Console.WriteLine("Listening: "+String(ip)+":"+String(port));
                    TcpClient client = listener.AcceptTcpClient();
                    Thread clientThread = new Thread(new ParameterizedThreadStart(Communicate);
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

            byte[] packet = new byte[4096]
            int bytesRead;
            while (true)
            {
                bytesRead = 0;
                try
                {
                    bytesRead = clientStream.Read(packet, 0, 4096)
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
                packets.push(packet);
            }
            client.Close();
        }
    }
}
