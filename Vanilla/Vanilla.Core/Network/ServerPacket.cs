using System.IO;

namespace Vanilla.Core.Network
{
    using Vanilla.Core.Opcodes;

    public class ServerPacket : BinaryWriter
    {
        public int Opcode;

        public ServerPacket(int opcode) : base(new MemoryStream())
        {
            Opcode = opcode;
        }

        public ServerPacket(WorldOpcodes worldOpcode) : this((int) worldOpcode) {}

        public ServerPacket(LoginOpcodes opcode) : this((byte) opcode) {}

        public byte[] Packet
        {
            get { return (BaseStream as MemoryStream).ToArray(); }
        }
    }
}
