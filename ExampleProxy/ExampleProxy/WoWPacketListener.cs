using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleProxy
{
    public enum Direction
    {
        Server2Client,
        Client2Server,
    }

    public delegate bool DetourPacketHandler(Direction direction, byte[] data);

    public class WoWPacketListener
    {
        private Dictionary<RealmPacketHeaders, DetourPacketHandler> Detours;
        private ProxyConnection Server;
        private ProxyConnection Client;

        public WoWPacketListener(ProxyConnection server, ProxyConnection client)
        {
            Detours = new Dictionary<RealmPacketHeaders, DetourPacketHandler>();
            Server = server;
            Client = client;

            Server.OnDataRecived += (data) => OnPacket(Direction.Client2Server, data);
            Client.OnDataRecived += (data) => OnPacket(Direction.Server2Client, data);
        }

        public void AddDetour(RealmPacketHeaders header, DetourPacketHandler detour)
        {
            if (Detours.ContainsKey(header))
            {
                throw new Exception("Only one detour per packet!");
            }
            else
            {
                Detours.Add(header, detour);

                Console.WriteLine("Detouring packet " + header.ToString());
            }
        }

        private void OnPacket(Direction direction, byte[] data)
        {
            RealmPacketHeaders packetHeader = (RealmPacketHeaders)data[0];

            string directionArrow = (direction == Direction.Client2Server) ? "-->" : "<--";            

            bool sendPacket = true;

            if (Detours.ContainsKey(packetHeader))
            {
                DetourPacketHandler packetHandler = Detours[packetHeader];

                sendPacket = packetHandler(direction, data);
            }

            if (sendPacket)
            {
                if (direction == Direction.Server2Client) Server.Send(data);
                if (direction == Direction.Client2Server) Client.Send(data);
            }

            Console.WriteLine("Client " + directionArrow + " Server - " + packetHeader.ToString() + " Sending: " + sendPacket);
        }
    }
}
