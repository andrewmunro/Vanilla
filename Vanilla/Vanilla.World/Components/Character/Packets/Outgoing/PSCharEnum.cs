using Vanilla.Character.Database;
using Vanilla.World.Database;

namespace Vanilla.World.Components.Character.Packets.Outgoing
{
    using System;
    using System.Collections.Generic;
    using Vanilla.Core;
    using Vanilla.Core.IO;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Network;

    public class PSCharEnum : WorldPacket
    {
        private WorldSession Session { get; set; }

        private DatabaseUnitOfWork<WorldDatabase> WorldDatabase { get { return Session.Server.Core.WorldDatabase; } } 

        public PSCharEnum(WorldSession session, List<character> characters) : base(WorldOpcodes.SMSG_CHAR_ENUM)
        {
            this.Session = session;
            this.Write((byte)characters.Count);

            foreach (character character in characters)
            {
                this.Write((ulong)character.guid);
                this.WriteCString(character.name);
                this.Write((byte)character.race);
                this.Write((byte)character.@class);

                this.Write((byte)character.gender);

                byte[] playerBytes = BitConverter.GetBytes(character.playerBytes);
                byte[] playerBytes2 = BitConverter.GetBytes(character.playerBytes2);

                this.Write((byte)playerBytes[0]); // Skin
                this.Write((byte)playerBytes[1]); // Face
                this.Write((byte)playerBytes[2]); // HairStyle
                this.Write((byte)playerBytes[3]); // HairColor
                this.Write((byte)playerBytes2[0]); // Accessory
                this.Write((byte)character.level);

                this.Write(0); // Zone ID
                Write((int)character.map);
                Write(character.position_x);
                Write(character.position_y);
                Write(character.position_z);

                this.Write(0); // Guild ID
                this.Write(0); // Character Flags

                this.Write((byte)0); // // Login Flags?

                this.Write(0); // Pet DisplayID
                this.Write(0); // Pet Level
                this.Write(0); // Pet FamilyID

                
                item_template[] equipment = ItemUtils.GenerateInventoryByIDs(Utils.CSVStringToIntArray(character.equipmentCache));

                for (int itemSlot = 0; itemSlot < 19; itemSlot++)
                {
                    if (equipment != null && equipment[itemSlot] != null)
                    {
                        Write(equipment[itemSlot].displayid); // Item DisplayID
                        Write((byte)equipment[itemSlot].InventoryType); // Item Inventory Type
                    }
                    else
                    {
                        Write(0);
                        Write((byte)0);
                    }
                }
                this.Write(0); // first bag display id
                this.Write((byte)0); // first bag inventory type
            }
        }
    }
}