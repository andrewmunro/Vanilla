using System.IO;
using Vanilla.Core.Constants;
using Vanilla.Core.Network.IO;
using Vanilla.Core.Opcodes;

namespace Vanilla.Core.Network.Packet
{
    public class WorldPacket : PacketWriter
    {
        public WorldPacket(WorldOpcodes opcode) : base((short)opcode, PacketHeaderType.WorldSmsg) { }
        public WorldPacket(short opcode) : base(opcode, PacketHeaderType.WorldSmsg) { }

        public override string ParseOpcode()
        {
            return ((WorldOpcodes)Opcode).ToString();
        }
    }
}
