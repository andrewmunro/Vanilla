namespace Vanilla.World.Components.Item
{
    using Vanilla.World.Game.Entity;
    using Vanilla.World.Game.Entity.Constants;

    public class Item
    {
        public ulong Creator { get; set; }

        public ObjectGUID GUID { get; private set; }

        public int Entry { get; set; }

        public int[] EnchantmentIDs { get; set; }

        public int RandomPropertyID { get; set; }

        public int ItemSuffixFactor { get; set; }

        public Item()
        {
            GUID = new ObjectGUID(TypeID.TYPEID_ITEM, HighGUID.HIGHGUID_ITEM);
        }
    }
}
