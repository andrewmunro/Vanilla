using System;
using System.Linq;
using System.Reflection;
using Milkshake;
using Milkshake.Communication.Outgoing.World.Movement;
using Milkshake.Game.Managers;
using Milkshake.Net;
using Milkshake.Tools;
using Milkshake.Tools.DBC;

namespace VanillaScript.Scripts
{
    class TestScript
    {
        public TestScript()
        {
            Log.Print(LogType.Debug, WorldServer.Sessions.Count);
            WorldServer.Sessions.ForEach(s => s.sendMessage("Hello World!!"));

            ChatManager.AddChatCommand("knockback", "knockbacks all players", Knockback);
        }

        private static void Knockback(WorldSession session, string[] args)
        {
            WorldServer.Sessions.ForEach(s => s.sendPacket(new PSMoveKnockBack(s.Entity, 10, 10, 10, 10)));
        }

        public void Unload()
        {
            Log.Print(LogType.Debug, "Unloading script...");
            ChatManager.RemoveChatCommand("knockback");
        }
    }
}
