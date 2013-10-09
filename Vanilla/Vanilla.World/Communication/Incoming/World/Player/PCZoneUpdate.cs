namespace Vanilla.World.Communication.Incoming.World.Player
{
    using Vanilla.Core.Network;

    public class PCZoneUpdate : PacketReader
    {
        #region Constructors and Destructors

        public PCZoneUpdate(byte[] data)
            : base(data)
        {
            this.ZoneID = ReadUInt32();
        }

        #endregion

        #region Public Properties

        public uint ZoneID { get; private set; }

        #endregion
    }
}