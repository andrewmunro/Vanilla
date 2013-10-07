using System.Collections.Generic;
using Vanilla.World.Network;
using Vanilla.World.Tools.Database.Helpers;

namespace Vanilla.World.Communication.Outgoing.World.ActionBarButton
{
    class PSActionButtons : ServerPacket
    {
        public PSActionButtons(Character character) : base(WorldOpcodes.SMSG_ACTION_BUTTONS)
        {
            List<CharacterActionBarButton> savedButtons = DBActionBarButtons.GetActionBarButtons(character);

            for (int button = 0; button < 120; button++)
            {
                int index = savedButtons.FindIndex(b => b.Button == button);

                CharacterActionBarButton currentButton = index != -1 ? savedButtons[index] : null;

                if (currentButton != null)
                {
                    uint packedData = (uint)currentButton.Action | (uint)currentButton.Type << 24;

                    Write(packedData);
                }
                else
                {
                    Write((uint) 0);
                }
            }
        }
    }
}
