using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;
using Milkshake.Tools.Database;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Communication.Outgoing.World.ActionBarButton
{
    class PSActionButtons : ServerPacket
    {
        public PSActionButtons(Character character) : base(Opcodes.SMSG_ACTION_BUTTONS)
        {
            List<CharacterActionBarButton> savedButtons = DBActionBarButtons.GetActionBarButtons(character);

            for (int button = 0; button < 120; button++)
            {
                int index = savedButtons.FindIndex(b => b.Button == button);

                CharacterActionBarButton currentButton = index != -1 ? savedButtons[index] : null;

                if (currentButton != null)
                {
                    UInt32 packedData = (UInt32)currentButton.Action | (UInt32)currentButton.Type << 24;

                    Write((UInt32) packedData);
                }
                else
                {
                    Write((UInt32) 0);
                }
            }
        }
    }
}
