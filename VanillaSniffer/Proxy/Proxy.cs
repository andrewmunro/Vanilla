using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using VanillaSniffer.Packet;

namespace VanillaSniffer.Proxy
{
    public class Proxy
    {
        public ProxyForwarder ClientToServer;
        public ProxyForwarder ServerToClient;

        public Proxy(Socket client)
        {
            ClientToServer = new ProxyForwarder(client, ProxyManager.RemoteServer, "clientToServer");
            ServerToClient = new ProxyForwarder(ProxyManager.RemoteServer, client, "serverToClient");

            ClientToServer.OnDataRecived += (packet) => OnClientPacket(packet);
            ServerToClient.OnDataRecived += (packet) => OnServerPacket(packet);
        }

        private void OnServerPacket(Byte[] packet)
        {
            Console.WriteLine("Server -> Client " + (PacketHeaders)packet[0]);
            if ((PacketHeaders)(byte)packet[0] == PacketHeaders.CMD_REALM_LIST)
            {
                PacketReader.ReadRealms(packet);
                packet = PacketWriter.WriteRealm(packet);
            }
            SendClient(packet);
        }

        private void OnClientPacket(Byte[] packet)
        {
            Console.WriteLine("Client -> Server " + (PacketHeaders)packet[0]);
            SendServer(packet);
        }

        public void SendClient(Byte[] packet)
        {
            ServerToClient.Send(packet);
        }

        public void SendServer(Byte[] packet)
        {
            ClientToServer.Send(packet);
        }
    }
}
