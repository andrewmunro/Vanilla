using Milkshake.Network;

namespace Milkshake.Communication.Incoming.Auth
{
    public class PCAuthLoginProof : PacketReader
    {        
        public byte OptCode { get; private set; }
        public byte[] A { get; private set; }
        public byte[] M1 { get; private set; }
        public byte[] CRC_Hash { get; private set; }
        public byte nKeys { get; private set; }
        public byte unk { get; private set; }

        public PCAuthLoginProof(byte[] data) : base(data)
        {
            OptCode = ReadByte();
            A = ReadBytes(32);
            M1 = ReadBytes(20);

            CRC_Hash = ReadBytes(20);
            nKeys = ReadByte();
            unk = ReadByte();
        }
    }
}
