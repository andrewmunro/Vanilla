namespace Vanilla.World.Components.Character.Packets.Outgoing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Vanilla.Core;
    using Vanilla.Core.Extensions;
    using Vanilla.Core.IO;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Network.Session;
    using Vanilla.Core.Opcodes;
    using Vanilla.Database.Character.Models;
    using Vanilla.Database.World.Models;
    using Vanilla.World.Components.Character.Constants;
    using Vanilla.World.Network;

    public class PSCharEnum : WorldPacket
    {
        private WorldSession Session { get; set; }

        private DatabaseUnitOfWork<WorldDatabase> WorldDatabase { get { return Session.Server.Core.WorldDatabase; } } 

        public PSCharEnum(WorldSession session, List<Character> characters) : base(WorldOpcodes.SMSG_CHAR_ENUM)
        {
            this.Session = session;
            this.Write((byte)characters.Count);

            foreach (Character character in characters)
            {
                this.Write((ulong)character.GUID);
                this.WriteCString(character.Name);
                this.Write((byte)character.Race);
                this.Write((byte)character.Class);

                this.Write((byte)character.Gender);

                byte[] playerBytes = BitConverter.GetBytes(character.PlayerBytes);
                byte[] playerBytes2 = BitConverter.GetBytes(character.PlayerBytes2);

                this.Write((byte)playerBytes[0]); // Skin
                this.Write((byte)playerBytes[1]); // Face
                this.Write((byte)playerBytes[2]); // HairStyle
                this.Write((byte)playerBytes[3]); // HairColor
                this.Write((byte)playerBytes2[0]); // Accessory
                this.Write((byte)character.Level);

                this.Write(0); // Zone ID
                Write((int)character.Map);
                Write(character.PositionX);
                Write(character.PositionY);
                Write(character.PositionZ);

                this.Write(0); // Guild ID
                this.Write(0); // Character Flags

                this.Write((byte)0); // // Login Flags?

                this.Write(0); // Pet DisplayID
                this.Write(0); // Pet Level
                this.Write(0); // Pet FamilyID

                
                ItemTemplate[] equipment = GenerateInventoryByIDs(Utils.CSVStringToIntArray(character.EquipmentCache));

                for (int itemSlot = 0; itemSlot < 19; itemSlot++)
                {
                    if (equipment != null && equipment[itemSlot] != null)
                    {
                        Write(equipment[itemSlot].Displayid); // Item DisplayID
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

        private ItemTemplate[] GenerateInventoryByIDs(int[] ids)
        {
            if (ids == null) return null;

            ItemTemplate[] inventory = new ItemTemplate[19];
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] > 0)
                {
                    var itemEntry = ids[i];
                    ItemTemplate item = WorldDatabase.GetRepository<ItemTemplate>().SingleOrDefault(it => it.Entry == itemEntry);
                    switch ((InventorySlotID)item.InventoryType)
                    {
                        case InventorySlotID.Head:
                            inventory[0] = item;
                            break;
                        case InventorySlotID.Shirt:
                            inventory[3] = item;
                            break;
                        case InventorySlotID.Vest:
                        case InventorySlotID.Robe:
                            inventory[4] = item;
                            break;
                        case InventorySlotID.Waist:
                            inventory[5] = item;
                            break;
                        case InventorySlotID.Legs:
                            inventory[6] = item;
                            break;
                        case InventorySlotID.Feet:
                            inventory[7] = item;
                            break;
                        case InventorySlotID.Wrist:
                            inventory[8] = item;
                            break;
                        case InventorySlotID.Hands:
                            inventory[9] = item;
                            break;
                        case InventorySlotID.Ring:
                            inventory[10] = item;
                            break;
                        case InventorySlotID.Trinket:
                            inventory[12] = item;
                            break;
                        case InventorySlotID.Mainhand:
                        case InventorySlotID.Onehand:
                        case InventorySlotID.Twohand:
                            inventory[15] = item;
                            break;
                        case InventorySlotID.Offhand:
                        case InventorySlotID.Shield:
                        case InventorySlotID.Bow:
                            inventory[16] = item;
                            break;
                    }
                }
            }
            return inventory;
        }
    }
}