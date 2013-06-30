using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Game.Constants.Game.World.Item
{
    public enum InventorySlotID : byte
    {
        None,
        Head,
        Neck,
        Shoulders,
        Shirt,
        Vest,
        Waist,
        Legs,
        Feet,
        Wrist,
        Hands,
        Ring,
        Trinket,
        Onehand,
        Shield,
        Bow,
        Back,
        Twohand,
        Bag,
        Tabbard,
        Robe,
        Mainhand,
        Offhand,
        Held,
        Ammo,
        Thrown,
        Ranged,
        Ranged2,
        Relic
    }

    public enum InventorySlotLoginID : byte
    {
        Head, //5x Write(0)
        Vest, //1x Write(0)
        Chest, //1x Write(0)
        Waist, //1x
        Legs, //1x
        Feet, //1x
        Bracers, //1x
        Gloves, //1x
        Ring, //3x
        Trinket, //5x
        WeaponMH, //1x
        WeaponOH, //5x

    }
}
