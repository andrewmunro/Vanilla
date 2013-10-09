namespace Vanilla.World.Communication.Incoming.World.Player
{
    #region

    using System;

    using Vanilla.Core.Network;

    #endregion

    public class PCSetSelection : PacketReader
    {
        #region Constructors and Destructors

        public PCSetSelection(byte[] data)
            : base(data)
        {
            this.GUID = ReadUInt64();
        }

        #endregion

        #region Public Properties

        public ulong GUID { get; private set; }

        #endregion
    }
}