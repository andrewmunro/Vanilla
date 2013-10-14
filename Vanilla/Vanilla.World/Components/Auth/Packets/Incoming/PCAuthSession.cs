namespace Vanilla.World.Components.Auth.Packets.Incoming
{
    #region

    using Vanilla.Core.Network.IO;

    #endregion

    internal sealed class PCAuthSession : PacketReader
    {
        #region Constructors and Destructors

        public PCAuthSession(byte[] data)
            : base(data)
        {
            this.ClientBuild = this.ReadInt32();
            this.Unk2 = this.ReadInt32();
            this.Username = this.ReadCString();
        }

        #endregion

        #region Public Properties

        public string Username { get; private set; }

        public int ClientBuild { get; private set; }

        public int Unk2 { get; private set; }

        #endregion
    }
}