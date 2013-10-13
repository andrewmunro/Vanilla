using Vanilla.Core.Constants;
using Vanilla.Core.Network.IO;
using Vanilla.Core.Opcodes;

namespace Vanilla.Core.Network.Packet
{
    public class RealmPacket : PacketWriter
    {
        public RealmPacket(LoginOpcodes opcode) : base((short)opcode, PacketHeaderType.RealmSmsg) { }

        public override string ParseOpcode()
        {
            return ((LoginOpcodes)Opcode).ToString();
        }
    }
}
