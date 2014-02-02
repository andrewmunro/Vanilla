namespace Vanilla.Script.Scripts
{
    using Vanilla.Server;
    using Vanilla.World.Game.Entity.Object.Creature;
    using Vanilla.World.Network;

    public class NPCCommands : VanillaPlugin
    {
        public NPCCommands()
        {
            AddChatCommand("move", "Moves target creature to current location", Move);
            AddChatCommand("info", "Displays information about target creature", Info);

            Core.Server.Sessions.ForEach(s => s.SendMessage("NPC Commands"));
        }

        private void Move(WorldSession session, string[] args)
        {
            if (session.Player.Target != null)
            {
                var target = (CreatureEntity)session.Player.Target;

                //if (target != null) target.Move(session.Player.Location.X, session.Player.Location.Y, session.Player.Location.Z);
            }

        }

        private void Info(WorldSession session, string[] args)
        {
            CreatureEntity target = (CreatureEntity)session.Player.Target;

            if (target != null)
            {
                session.SendMessage("-- NPC Info --");
                session.SendMessage("Name: " + target.Name);
                //session.sendMessage("Entry: " + target.Entry);
                //session.sendMessage("TypeID: " + target.TypeID);
                session.SendMessage("ModelID: " + target.Info.DisplayID);
            }
        }

        public override void Unload()
        {
            RemoveChatCommand("move");
            RemoveChatCommand("info");
        }
    }
}
