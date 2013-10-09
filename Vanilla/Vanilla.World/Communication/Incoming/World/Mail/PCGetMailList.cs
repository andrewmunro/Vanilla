namespace Vanilla.World.Communication.Incoming.World.Mail
{
    public class PCGetMailList : PacketReader
    {
        #region Constructors and Destructors

        public PCGetMailList(byte[] data)
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