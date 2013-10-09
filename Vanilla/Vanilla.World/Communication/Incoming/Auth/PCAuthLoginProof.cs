namespace Vanilla.World.Communication.Incoming.Auth
{
    using Vanilla.Core.Network;

    public class PCAuthLoginProof : PacketReader
    {
        #region Constructors and Destructors

        public PCAuthLoginProof(byte[] data)
            : base(data)
        {
            this.OptCode = ReadByte();
            this.A = ReadBytes(32);
            this.M1 = ReadBytes(20);

            this.CRC_Hash = ReadBytes(20);
            this.nKeys = ReadByte();
            this.unk = ReadByte();
        }

        #endregion

        #region Public Properties

        public byte[] A { get; private set; }
        public byte[] CRC_Hash { get; private set; }
        public byte[] M1 { get; private set; }
        public byte OptCode { get; private set; }
        public byte nKeys { get; private set; }
        public byte unk { get; private set; }

        #endregion
    }
}