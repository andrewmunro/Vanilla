namespace Vanilla.World.Communication.Incoming.World
{
    using Vanilla.Core.Network;

    public class PCPlayerLogin : PacketReader
    {
        #region Constructors and Destructors

        public PCPlayerLogin(byte[] data)
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