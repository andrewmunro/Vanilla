namespace Vanilla.World.Communication.Incoming.World.Player
{
    using Vanilla.Core.Network;

    public class PCEmote : PacketReader
    {
        #region Constructors and Destructors

        public PCEmote(byte[] data)
            : base(data)
        {
            this.EmoteID = ReadUInt32();
        }

        #endregion

        #region Public Properties

        public uint EmoteID { get; private set; }

        #endregion
    }
}