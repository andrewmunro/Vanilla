using Vanilla.Core.Network.IO;

namespace Vanilla.World.Communication.Incoming.World.GameObject
{
    using Vanilla.Core.Network;

    public class PCGameObjectQuery : PacketReader
    {
        #region Constructors and Destructors

        public PCGameObjectQuery(byte[] data)
            : base(data)
        {
            this.EntryID = ReadUInt32();
            this.GUID = ReadUInt32();
        }

        #endregion

        #region Public Properties

        public uint EntryID { get; private set; }
        public uint GUID { get; private set; }

        #endregion
    }
}