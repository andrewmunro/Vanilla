namespace Vanilla.World.Components.GameObject.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    public class PCGameObjectUse : PacketReader
    {

        public PCGameObjectUse(byte[] data)
            : base(data)
        {
            this.GUID = this.ReadUInt64();
        }

        public ulong GUID { get; set; }

    }
}