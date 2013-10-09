namespace Vanilla.World.Communication.Incoming.World.Auth
{
    #region

    using System;

    using Vanilla.Core.Network;

    #endregion

    internal class PCAuthSession : PacketReader
    {
        #region Constructors and Destructors

        public PCAuthSession(byte[] data)
            : base(data)
        {
            this.ClientBuild = ReadInt32();
            this.Unk2 = ReadInt32();
            this.Username = ReadCString();
        }

        #endregion

        #region Public Properties

        public string Username { get; private set; }

        public int ClientBuild { get; private set; }

        public int Unk2 { get; private set; }

        #endregion
    }
}