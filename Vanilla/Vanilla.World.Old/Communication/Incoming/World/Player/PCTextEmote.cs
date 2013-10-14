using Vanilla.Core.Network.IO;

namespace Vanilla.World.Communication.Incoming.World.Player
{
    using Vanilla.Core.Network;

    public class PCTextEmote : PacketReader
    {
        #region Constructors and Destructors

        public PCTextEmote(byte[] data)
            : base(data)
        {
            this.TextID = ReadUInt32();
            this.EmoteID = ReadUInt32();
            this.GUID = ReadInt32();
        }

        #endregion

        #region Public Properties

        public uint EmoteID { get; private set; }
        public int GUID { get; private set; }
        public uint TextID { get; private set; }

        #endregion
    }
}