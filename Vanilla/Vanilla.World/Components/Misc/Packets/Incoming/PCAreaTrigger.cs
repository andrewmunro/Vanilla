namespace Vanilla.World.Components.Misc.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    public class PCAreaTrigger : PacketReader
    {
        public PCAreaTrigger(byte[] data)
            : base(data)
        {
            this.TriggerID = this.ReadUInt32();
        }

        public uint TriggerID { get; private set; }
    }
}