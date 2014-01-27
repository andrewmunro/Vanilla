namespace Vanilla.World.Components.ActionBar.Packets.Outgoing
{
    using System.Collections.Generic;
    using System.Linq;

    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;
    using Vanilla.Database.Character.Models;

    internal sealed class PSActionButtons : WorldPacket
    {
        public PSActionButtons(ActionButtonCollection collection)
            : base(WorldOpcodes.SMSG_ACTION_BUTTONS)
        {
            var savedButtons = collection.ToList();

            for (int button = 0; button < 120; button++)
            {
                int index = savedButtons.FindIndex(b => b.Button == button);

                CharacterAction currentButton = index != -1 ? savedButtons[index] : null;

                if (currentButton != null)
                {
                    uint packedData = (uint)currentButton.Action | (uint)currentButton.Type << 24;

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