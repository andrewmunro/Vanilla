using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Sessions;
using Milkshake.Network;
using Milkshake.Tools;
using Milkshake.Net;
using Milkshake.Tools.Database;
using Milkshake.Communication.Outgoing.World;

namespace Milkshake
{
    public class MilkShake
    {

        static void Main(string[] args)
        {
            DB.Boot();



            RealmServer realm = new RealmServer();
            WorldServer world = new WorldServer();
            world.Start(120, 50);
            realm.Start(3724, 50);           
            /*
            //                     
            string updatePacket = "01 00 00 00" + // Object Count
                                  "00" +          // hasTransport
                                  "03" +          // updatetype 3 == UPDATETYPE_CREATE_OBJECT2
                                  "01 01 04 71 00 00 00 00" + // GUID
                                  "AD" + // objectTypeId ??
                                  "5E" + // Update flags
                                  "00 00 7B 34 37 C5 E7 3B 85 C3 06 52 56 42 CA A9 49 3F 00 00 00 00 00 00 20 40 00 00 E0 40 00 00 90 40 71 1C 97 40 00 00 20 40 E0 0F 49 40 01 00 00 00 29 15 00 40 54 1D C0 00 00 00 00 00 80 20 00 00 C0 D9 04 C2 4F 38 19 00 00 06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 E0 B6 6D DB B6 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 6C 80 00 00 00 00 00 00 80 00 40 00 00 80 3F 00 00 00 00 20 00 00 00 00 00 00 01 00 00 00 19 00 00 00 CD CC AC 3F 54 00 00 00 64 00 00 00 54 00 00 00 E8 03 00 00 64 00 00 00 01 00 00 00 06 00 00 00 06 01 00 01 08 00 00 00 99 09 00 00 09 00 00 00 01 00 00 00 D0 07 00 00 D0 07 00 00 D0 07 00 00 3B 00 00 00 3B 00 00 00 25 49 D2 40 25 49 F2 40 00 EE 11 00 00 00 80 3F 1C 00 00 00 0F 00 00 00 18 00 00 00 0F 00 00 00 16 00 00 00 1E 00 00 00 0A 00 00 00 14 00 00 00 00 28 00 00 27 00 00 00 06 00 00 00 DC B6 ED 3F 6E DB 36 40 07 00 07 01 02 00 00 01 90 01 00 00 1A 00 00 00 01 00 01 00 2C 00 00 00 01 00 05 00 36 00 00 00 01 00 05 00 5F 00 00 00 01 00 05 00 6D 00 00 00 2C 01 2C 01 73 00 00 00 2C 01 2C 01 A0 00 00 00 01 00 05 00 A2 00 00 00 01 00 05 00 9D 01 00 00 01 00 01 00 9E 01 00 00 01 00 01 00 9F 01 00 00 01 00 01 00 B1 01 00 00 01 00 01 00 02 00 00 00 48 E1 9A 40 3E 0A 17 3F 3E 0A 17 3F CD CC 0C 3F 00 00 04 00 29 00 00 00 0A 00 00 00 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F FF FF FF FF ";

          
            byte[] data = Helper.StringToByteArray(updatePacket.Replace(" ", ""));

            PacketReader reader = new PacketReader(data);

            byte objectCount = reader.ReadByte();
            int GUID = reader.ReadInt32();
            ObjectUpdateType type = (ObjectUpdateType)reader.ReadByte();



            Console.WriteLine(objectCount);
            */
            while (true)
            {
                Console.ReadLine();
            }

        }

        

       
    }

    public class RealmServer : MilkTCPListener
    {
        public override ISession GenerateSession(int connectionID, System.Net.Sockets.Socket connectionSocket)
        {
            return new RealmSession(connectionID, connectionSocket);
        }
    }

    public class WorldServer : MilkTCPListener
    {
        public static List<WorldSession> Sessions = new List<WorldSession>();
        public int connectionID = 0;
        public override ISession GenerateSession(int connectionID, System.Net.Sockets.Socket connectionSocket)
        {
            connectionID++;
            WorldSession session = new WorldSession(connectionID, connectionSocket);
            Sessions.Add(session);

            Console.WriteLine("------ NEW SESSION " + session.ConnectionID);

            return session;
        }
    }

    


}
