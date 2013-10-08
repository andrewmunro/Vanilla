// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSCharEnum.cs" company="">
//   
// </copyright>
// <summary>
//   The ps char enum.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login.Communication.Outgoing.Char
{
    using System.Collections.Generic;
    using System.IO;

    using Vanilla.Core.Constants;
    using Vanilla.Core.Network;

    /// <summary>
    /// The ps char enum.
    /// </summary>
    public class PSCharEnum : PacketWriter
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PSCharEnum"/> class.
        /// </summary>
        /// <param name="characters">
        /// The characters.
        /// </param>
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
                Write(character.MapID);
                Write(character.X);
                Write(character.Y);
                Write(character.Z);

                Write(0); // Guild ID
                Write(0); // Character Flags

                Write((byte)0); // // Login Flags?

                Write(0); // Pet DisplayID
                Write(0); // Pet Level
                Write(0); // Pet FamilyID

                ItemTemplateEntry[] Equipment =
                    DBC.ItemTemplates.GenerateInventoryByIDs(Helper.CSVStringToIntArray(character.Equipment));

                for (int itemSlot = 0; itemSlot < 19; itemSlot++)
                {
                    if (Equipment[itemSlot] != null)
                    {
                        Write((int)Equipment[itemSlot].displayid); // Item DisplayID
                        Write((byte)Equipment[itemSlot].InventoryType); // Item Inventory Type
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

        /// <summary>
        /// Gets the packet.
        /// </summary>
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