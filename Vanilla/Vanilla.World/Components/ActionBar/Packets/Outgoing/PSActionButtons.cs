using Vanilla.Character.Database;

namespace Vanilla.World.Components.ActionBar.Packets.Outgoing
{
    using System.Linq;

    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    internal sealed class PSActionButtons : WorldPacket
    {
        public PSActionButtons(ActionButtonCollection collection)
            : base(WorldOpcodes.SMSG_ACTION_BUTTONS)
        {
            var savedButtons = collection.ToList();

            for (int button = 0; button < 120; button++)
            {
                int index = savedButtons.FindIndex(b => b.button == button);

                character_action currentButton = index != -1 ? savedButtons[index] : null;

                if (currentButton != null)
                {
                    uint packedData = (uint)currentButton.action | (uint)currentButton.type << 24;

                    this.Write(packedData);
                }
                else
                {
                    this.Write((uint)0);
                }
            }
        }
    }
}