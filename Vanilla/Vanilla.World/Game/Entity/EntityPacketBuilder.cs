namespace Vanilla.World.Game.Entity
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    using Vanilla.Core.Extensions;
    using Vanilla.World.Components.Item;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Entity.Tools;

    public abstract class EntityPacketBuilder
    {
        public Queue<UpdateFieldEntry> UpdateQueue = new Queue<UpdateFieldEntry>();

        private byte[] cachedUpdatePacket;

        private byte[] cachedCreatePacket;

        public byte[] UpdatePacket()
        {
            if (this.UpdateQueue.Count == 0 && this.cachedUpdatePacket != null) return this.cachedUpdatePacket;
            return this.cachedUpdatePacket = this.BuildUpdatePacket();
        }

        public byte[] CreatePacket()
        {
            if (this.UpdateQueue.Count == 0 && this.cachedCreatePacket != null) return this.cachedCreatePacket;
            return this.cachedCreatePacket = this.BuildCreatePacket();
        }

        public int MaskSize { get; private set; }
        public BitArray Mask { get; private set; }
        public Hashtable UpdateData { get; private set; }
        public virtual int DataLength { get; private set; }

        public EntityPacketBuilder()
        {
            this.MaskSize = ((this.DataLength) + 32) / 32;
            this.Mask = new BitArray(this.DataLength, false);
            this.UpdateData = new Hashtable();
        }

        protected void SetInfoFields<TI>(TI info) where TI : EntityInfo
        {
            foreach (UpdateFieldEntry entry in info.CreationUpdateFieldEntries)
            {
                byte key = entry.UpdateField;
                Type type = entry.PropertyInfo.PropertyType;
                var value = entry.PropertyInfo.GetValue(info);

                if (entry.Index == -1)
                {
                    if (type == typeof(Int32)) this.SetUpdateField<uint>((int)key, Convert.ToUInt32(value));
                    if (type == typeof(Byte)) this.SetUpdateField<byte>((int)key, Convert.ToByte(value));
                    if (type == typeof(UInt16)) this.SetUpdateField<UInt16>((int)key, Convert.ToUInt16(value));
                    if (type == typeof(UInt64)) this.SetUpdateField<ulong>((int)key, Convert.ToUInt64(value));
                    if (type == typeof(Single)) this.SetUpdateField<float>((int)key, Convert.ToSingle(value));
/*                    if (type == typeof(Item[]))
                    {
                        var values = value as Item[];
                        for (int i = 0; i < values.Length; i++)
                        {
                            var item = values[i];
                            this.SetUpdateField<ulong>((int)EUnitFields.PLAYER_FIELD_INV_SLOT_HEAD + (i * 2), item.GUID.RawGUID);
                            this.SetUpdateField<ulong>((int)EUnitFields.PLAYER_VISIBLE_ITEM_1_CREATOR + (i * 12), item.Creator);

                            var itemBase = (int)EUnitFields.PLAYER_VISIBLE_ITEM_1_0 + (i * 12);

                            this.SetUpdateField<int>(itemBase, item.Entry);
                            for (int j = 0; j < item.EnchantmentIDs.Length; j++)
                            {
                                this.SetUpdateField<int>(itemBase + 1 + j, item.EnchantmentIDs[j]);
                            }

                            this.SetUpdateField<int>((int)EUnitFields.PLAYER_VISIBLE_ITEM_1_PROPERTIES + (i * 12), item.RandomPropertyID);
                            this.SetUpdateField<int>((int)EUnitFields.PLAYER_VISIBLE_ITEM_1_PROPERTIES + 1 + (i * 12), item.ItemSuffixFactor);
                        }
                    }*/
                }
                else
                {
                    if (type == typeof(Byte)) this.SetUpdateField<byte>((int)key, Convert.ToByte(value), (byte)entry.Index);
                }
            }
        }

        public void SetUpdateField<T>(int index, T value, byte offset = 0)
        {
            //UpdateCount++;

            if (index == 1)
            {
                Console.WriteLine("s");
            }

            switch (value.GetType().Name)
            {
                case "SByte":
                case "Int16":
                    {
                        this.Mask.Set(index, true);

                        if (this.UpdateData.ContainsKey(index))
                            this.UpdateData[index] = (int)((int)this.UpdateData[index] | (int)((int)Convert.ChangeType(value, typeof(int)) << (offset * (value.GetType().Name == "Byte" ? 8 : 16))));
                        else
                            this.UpdateData[index] = (int)((int)Convert.ChangeType(value, typeof(int)) << (offset * (value.GetType().Name == "Byte" ? 8 : 16)));

                        break;
                    }
                case "Byte":
                case "UInt16":
                    {
                        this.Mask.Set(index, true);

                        if (this.UpdateData.ContainsKey(index))
                            this.UpdateData[index] = (uint)((uint)this.UpdateData[index] | (uint)((uint)Convert.ChangeType(value, typeof(uint)) << (offset * (value.GetType().Name == "Byte" ? 8 : 16))));
                        else
                            this.UpdateData[index] = (uint)((uint)Convert.ChangeType(value, typeof(uint)) << (offset * (value.GetType().Name == "Byte" ? 8 : 16)));

                        break;
                    }
                case "Int64":
                    {
                        this.Mask.Set(index, true);
                        this.Mask.Set(index + 1, true);

                        long tmpValue = (long)Convert.ChangeType(value, typeof(long));

                        this.UpdateData[index] = (uint)(tmpValue & Int32.MaxValue);
                        this.UpdateData[index + 1] = (uint)((tmpValue >> 32) & Int32.MaxValue);

                        break;
                    }
                case "UInt64":
                    {
                        this.Mask.Set(index, true);
                        this.Mask.Set(index + 1, true);

                        ulong tmpValue = (ulong)Convert.ChangeType(value, typeof(ulong));

                        this.UpdateData[index] = (uint)(tmpValue & UInt32.MaxValue);
                        this.UpdateData[index + 1] = (uint)((tmpValue >> 32) & UInt32.MaxValue);

                        break;
                    }
                default:
                    {
                        this.Mask.Set(index, true);
                        this.UpdateData[index] = value;

                        break;
                    }
            }
        }

        public void WriteUpdateFields(BinaryWriter packet)
        {
            packet.Write((byte)this.MaskSize);

            packet.WriteBitArray(this.Mask, (this.MaskSize * 4));    // Int32 = 4 Bytes

            for (int i = 0; i < this.Mask.Count; i++)
            {
                if (this.Mask.Get(i))
                {
                    try
                    {
                        switch (this.UpdateData[i].GetType().Name)
                        {
                            case "UInt32":
                                packet.Write((uint)this.UpdateData[i]);
                                break;
                            case "Single":
                                packet.Write((float)this.UpdateData[i]);
                                break;
                            default:
                                packet.Write((int)this.UpdateData[i]);
                                break;
                        }
                    }
                    catch
                    {
                    }
                }
            }

            this.Mask.SetAll(false);
        }

        protected abstract byte[] BuildUpdatePacket();

        protected abstract byte[] BuildCreatePacket();
    }
}
