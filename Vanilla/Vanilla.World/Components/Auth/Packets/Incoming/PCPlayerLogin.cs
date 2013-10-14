namespace Vanilla.World.Components.Auth.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    public sealed class PCPlayerLogin : PacketReader
    {
        #region Constructors and Destructors

        public PCPlayerLogin(byte[] data)
            : base(data)
        {
            this.GUID = this.ReadUInt32();
        }

        #endregion

        #region Public Properties

        public uint GUID { get; private set; }

        #endregion
    }
}