using System;
using System.Linq;
using Milkshake;
using Milkshake.Communication.Outgoing.World.Movement;
using Milkshake.Game.Managers;
using Milkshake.Net;
using Milkshake.Tools;

namespace VanillaScript.Scripts
{
    class Boom
    {
        public Boom()
        {
            Log.Print(LogType.Debug, "BOOM!");

            //TODO Figure out why the FK this doesnt work :(
            Log.Print(LogType.Debug, WorldServer.Sessions.Count);
            WorldServer.Sessions.ForEach(s => s.sendMessage("BOOOM!!"));
        }
    }
}
