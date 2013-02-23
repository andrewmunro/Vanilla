using Milkshake.Network;

namespace Milkshake.Communication.Incoming.Auth
{
    public class AuthLogonProof : PacketReader
    {        
        public byte OptCode;
        public byte[] A;
        public byte[] M1;
        public byte[] CRC_Hash;
        public byte nKeys;
        public byte unk;

        public AuthLogonProof(byte[] data) : base(data)
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
