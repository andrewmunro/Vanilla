namespace Vanilla.World.Communication.Outgoing.World.ActionBarButton
{
    #region

    using System.Collections.Generic;
    using System.Linq;

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Character.Database.Models;

    #endregion

    internal sealed class PSActionButtons : ServerPacket
    {
        #region Constructors and Destructors

        public PSActionButtons(Character character)
            : base(WorldOpcodes.SMSG_ACTION_BUTTONS)
        {
            List<CharacterAction> savedButtons = VanillaWorld.CharacterDatabase.CharacterActions.Where(ca => ca.GUID == character.GUID).ToList();

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
                    Write((uint)0);
                }
            }
        }

        #endregion
    }
}