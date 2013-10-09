namespace Vanilla.World.Communication.Incoming.World.Player
{
    public class PCNameQuery : PacketReader
    {
        #region Constructors and Destructors

        public PCNameQuery(byte[] data)
            : base(data)
        {
            this.GUID = ReadUInt32();
        }

        #endregion

        #region Public Properties

        public uint GUID { get; private set; }

        #endregion
    }
}