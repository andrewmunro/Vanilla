namespace Vanilla.World.Communication.Incoming.World.Player
{
    using Vanilla.Core.Network;

    public class PCPing : PacketReader
    {
        #region Constructors and Destructors

        public PCPing(byte[] data)
            : base(data)
        {
            this.Ping = ReadUInt32();
            this.Latency = ReadUInt32();
        }

        #endregion

        #region Public Properties

        public uint Latency { get; private set; }
        public uint Ping { get; private set; }

        #endregion
    }
}