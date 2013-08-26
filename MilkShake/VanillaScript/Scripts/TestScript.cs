using System;
using System.Linq;
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
            WorldServer.Sessions.ForEach(s => s.sendPacket(new PSMoveKnockBack(s.Entity, 1, 1, 10, 10)));
            WorldServer.Sessions.ForEach(s => s.sendMessage("Hello World!!"));
        }

        public void Unload()
        {
            Log.Print(LogType.Debug, "Unloading script...");
        }
    }
}
