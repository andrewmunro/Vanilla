namespace Vanilla.World.Communication.Outgoing.Char
{
    #region

    using System.Collections.Generic;
    using System.IO;
    using Character.Database.Models;
    using Vanilla.Core;
    using Vanilla.Core.Constants;
    using Vanilla.Core.Network;
    using Vanilla.World.Tools.DBC;
    using Vanilla.World.Tools.DBC.Tables;

    #endregion

    public class PSCharEnum : PacketWriter
    {
        #region Constructors and Destructors

        public PSCharEnum(List<Character> characters)
            : base(PacketHeaderType.WorldSmsg)
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

                ItemTemplateEntry[] equipment =
                    DBC.ItemTemplates.GenerateInventoryByIDs(Utils.CSVStringToIntArray(character.EquipmentCache));

                for (int itemSlot = 0; itemSlot < 19; itemSlot++)
                {
                    if (equipment[itemSlot] != null)
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

                Write(0); // first bag display id
                Write((byte)0); // first bag inventory type
            }
        }

        #endregion

        #region Public Properties

        public byte[] Packet
        {
            get
            {
                return (BaseStream as MemoryStream).ToArray();
            }
        }

        #endregion
    }
}