namespace Vanilla.Login.Communication.Incoming.Auth
{
    using Vanilla.Core.Network;

    public sealed class PCAuthLoginProof : PacketReader
    {
        #region Constructors and Destructors

        public PCAuthLoginProof(byte[] data)
            : base(data)
        {
            this.OptCode = ReadByte();
            this.A = ReadBytes(32);
            this.M1 = ReadBytes(20);

            this.CrcHash = ReadBytes(20);
            this.NKeys = ReadByte();
            this.Unk = ReadByte();
        }

        #endregion

        #region Public Properties

        public byte[] A { get; private set; }

        public byte[] CrcHash { get; private set; }

        public byte[] M1 { get; private set; }

        public byte OptCode { get; private set; }

        public byte NKeys { get; private set; }

        public byte Unk { get; private set; }

        #endregion
    }
}