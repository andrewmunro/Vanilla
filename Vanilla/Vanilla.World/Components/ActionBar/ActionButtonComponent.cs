using Vanilla.Character.Database;

namespace Vanilla.World.Components.ActionBar
{
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.ActionBar.Packets.Incoming;
    using Vanilla.World.Components.ActionBar.Packets.Outgoing;
    using Vanilla.World.Network;

    public class ActionButtonComponent : WorldServerComponent
    {
        public ActionButtonComponent(VanillaWorld vanillaWorld)
            : base(vanillaWorld)
        {
            this.Router.AddHandler<PCSetActionButton>(WorldOpcodes.CMSG_SET_ACTION_BUTTON, this.OnSetActionButton);
        }

        public void SendInitialButtons(WorldSession session)
        {
            session.SendPacket(new PSActionButtons(session.Player.ActionButtonCollection));
        }

        private void OnSetActionButton(WorldSession session, PCSetActionButton packet)
        {
            if (packet.Action == 0)
            {
                session.Player.ActionButtonCollection.RemoveActionButton(packet.Button);
            }
            else
            {
                session.Player.ActionButtonCollection.AddActionButton(new character_action() { guid = session.Player.ObjectGUID.Low, action = packet.Action, button = packet.Button, type = (byte)packet.Type });
            }
        }
    }
}
