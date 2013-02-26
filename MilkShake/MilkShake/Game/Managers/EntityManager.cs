using Milkshake.Communication.Outgoing.World.Update;
using Milkshake.Tools.Database.Tables;
using Milkshake.Net;

namespace Milkshake.Game.Managers
{
    public class EntityManager
    {
        public static void Boot()
        {
            
        }

        public static void SpawnPlayer(Character character)
        {
            WorldServer.Sessions.FindAll(s => s.Character != character).ForEach(s =>
            {
                s.sendMessage("Spawning: " + character.Name);
                s.sendPacket(PSUpdateObject.CreateCharacterUpdate(character));
            });
        }

        public static void SendPlayers(WorldSession session)
        {
            WorldServer.Sessions.FindAll(s => s.Character != null).FindAll(s => s.Character != session.Character).ForEach(s =>
            {
                session.sendMessage("Spawning: " + s.Character);
                session.sendPacket(PSUpdateObject.CreateCharacterUpdate(s.Character));
            });
        }
    }
}
