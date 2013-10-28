namespace Vanilla.World.Game.Entity.UpdateBuilder
{
    using System.Collections.Generic;
    using System.IO;

    using Vanilla.Core.Extensions;

    public abstract class EntityPacketBuilder
    {
        public Queue<UpdateFieldEntry> UpdateQueue = new Queue<UpdateFieldEntry>();

        private byte[] cachedUpdatePacket;

        private byte[] cachedCreatePacket;

        public byte[] UpdatePacket()
        {
            if (UpdateQueue.Count == 0 && cachedUpdatePacket != null) return cachedUpdatePacket;
            return cachedUpdatePacket = BuildUpdatePacket();
        }

        public byte[] CreatePacket()
        {
            if (UpdateQueue.Count == 0 && cachedCreatePacket != null) return cachedCreatePacket;
            return cachedCreatePacket = BuildCreatePacket();
        }

        protected void WriteCreationFields(BinaryWriter packet)
        {
            packet.Write((byte)MaskSize);

            packet.WriteBitArray(Mask, (MaskSize * 4));    // Int32 = 4 Bytes

            for (int i = 0; i < Mask.Count; i++)
            {
                if (Mask.Get(i))
                {
                    try
                    {
                        switch (UpdateData[i].GetType().Name)
                        {
                            case "UInt32":
                                packet.Write((uint)UpdateData[i]);
                                break;
                            case "Single":
                                packet.Write((float)UpdateData[i]);
                                break;
                            default:
                                packet.Write((int)UpdateData[i]);
                                break;
                        }
                    }
                    catch
                    {
                    }
                }
            }

            Mask.SetAll(false);
            UpdateCount = 0;
        }

        protected abstract byte[] BuildUpdatePacket();

        protected abstract byte[] BuildCreatePacket();
    }
}
