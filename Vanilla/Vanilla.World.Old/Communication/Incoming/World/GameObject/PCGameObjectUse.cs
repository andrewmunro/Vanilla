using Vanilla.Core.Network.IO;

namespace Vanilla.World.Communication.Incoming.World.GameObject
{
    using Vanilla.Core.Network;

    public class PCGameObjectUse : PacketReader
    {
        #region Constructors and Destructors

        public PCGameObjectUse(byte[] data)
            : base(data)
        {
            this.GUID = ReadUInt64();
        }

        #endregion

        #region Public Properties

        public ulong GUID { get; set; }

        #endregion
    }
}