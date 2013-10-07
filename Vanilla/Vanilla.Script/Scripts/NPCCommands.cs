using Milkshake;
using Milkshake.Game.Entitys;
using Milkshake.Game.Managers;
using Milkshake.Net;
using Milkshake.Tools;

namespace Vanilla.Script.Scripts
{
    public class NPCCommands : VanillaPlugin
    {
        public NPCCommands()
        {
            ChatManager.AddChatCommand("move", "move", Move);
            ChatManager.AddChatCommand("info", "info", Info);

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
