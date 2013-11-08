namespace Vanilla.World.Components.Movement.Packets.Incoming
{
    using System;
    using System.IO;

    using Vanilla.Core.Network.IO;

    public sealed class PCMoveTimeSkipped : PacketReader
    {
        public ulong GUID;

        public uint OutOfSyncDelay;

        public PCMoveTimeSkipped(byte[] data) : base(data)
        {
            GUID = this.ReadPackedGuid(this);
            OutOfSyncDelay = ReadUInt32();
        }

        public ulong ReadPackedGuid(BinaryReader reader)
        {
            byte mask = reader.ReadByte();

            if (mask == 0)
            {
                return 0;
            }

            ulong res = 0;

            int i = 0;
            while (i < 8)
            {
                if ((mask & 1 << i) != 0)
                {
                    res += (ulong)reader.ReadByte() << (i * 8);
                }

                i++;
            }

            return res;
        }
    }
}
