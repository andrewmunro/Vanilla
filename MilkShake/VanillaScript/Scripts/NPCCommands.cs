using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Tools;
using Milkshake.Game.Managers;
using Milkshake.Net;
using Milkshake.Game.Entitys;
using Milkshake;

namespace VanillaScript.Scripts
{
    public class NPCCommands : VanillaPlugin
    {
        public NPCCommands()
        {
            ChatManager.AddChatCommand("npc", "move", Move);
            ChatManager.AddChatCommand("npc", "info", Info);

            WorldServer.Sessions.ForEach(s => s.sendMessage("NPC Commands"));
        }

        private static void Move(WorldSession session, string[] args)
        {
            UnitEntity target = session.Entity.Target;

            if (target != null) target.Move(session.Entity.X, session.Entity.Y, session.Entity.Z);
        }

        private static void Info(WorldSession session, string[] args)
        {
            UnitEntity target = session.Entity.Target;

            if (target != null)
            {
                session.sendMessage("-- NPC Info --");
                session.sendMessage("Name: " + target.Name);
                //session.sendMessage("Entry: " + target.Entry);
                //session.sendMessage("TypeID: " + target.TypeID);
                session.sendMessage("ModelID: " + target.DisplayID);
            }
        }

        public override void Unload()
        {
            ChatManager.RemoveChatCommand("npc");
        }
    }
}
