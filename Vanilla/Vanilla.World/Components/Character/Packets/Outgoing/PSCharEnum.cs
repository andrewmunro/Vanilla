using System.Collections.Generic;
using Vanilla.Core;
using Vanilla.Core.Network.Packet;
using Vanilla.Core.Opcodes;
using Vanilla.Database.Character.Models;

namespace Vanilla.World.Components.Char.Packets.Outgoing
{
    public class PSCharEnum : WorldPacket
    {
        public PSCharEnum(List<Character> characters) : base(WorldOpcodes.SMSG_CHAR_ENUM)
        {
            Write((byte)characters.Count);

            foreach (Character character in characters)
            {
                Write((ulong)character.GUID);
                WriteCString(character.Name);
                Write((byte)character.Race);
                Write((byte)character.Class);

                Write((byte)character.Gender);
                Write((byte)character.Skin);
                Write((byte)character.Face);
                Write((byte)character.HairStyle);
                Write((byte)character.HairColor);
                Write((byte)character.Accessory);
                Write((byte)character.Level);

                Write(0); // Zone ID
                Write(character.Map);
                Write(character.PositionX);
                Write(character.PositionY);
                Write(character.PositionZ);

                Write(0); // Guild ID
                Write(0); // Character Flags

                Write((byte)0); // // Login Flags?

                Write(0); // Pet DisplayID
                Write(0); // Pet Level
                Write(0); // Pet FamilyID

                for (int itemSlot = 0; itemSlot < 19; itemSlot++)
                {
                     Write(0);
                        Write((byte)0);
                    /*
                    if (equipment[itemSlot] != null)
                    {
                        Write(equipment[itemSlot].displayid); // Item DisplayID
                        Write((byte)equipment[itemSlot].InventoryType); // Item Inventory Type
                    }
                    */
                }

                Write(0); // first bag display id
                Write((byte)0); // first bag inventory type
            }
        }
    }
}