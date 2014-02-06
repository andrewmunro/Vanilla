namespace Vanilla.Core
{
    using Vanilla.Core.Constants;
    using Vanilla.Core.IO;
    using Vanilla.Database.World.Models;

    public class ItemUtils
    {
        public static ItemTemplate[] GenerateInventoryByIDs(int[] ids)
        {
            if (ids == null) return null;

            ItemTemplate[] inventory = new ItemTemplate[19];
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] > 0)
                {
                    var itemEntry = ids[i];
                    ItemTemplate item = new DatabaseUnitOfWork<WorldDatabase>().GetRepository<ItemTemplate>().SingleOrDefault(it => it.Entry == itemEntry);
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
