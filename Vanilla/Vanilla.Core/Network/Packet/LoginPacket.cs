using System.IO;
using Vanilla.Core.Constants;
using Vanilla.Core.Network.IO;
using Vanilla.Core.Opcodes;

namespace Vanilla.Core.Network.Packet
{
    public class LoginPacket : PacketWriter
    {
        public LoginPacket(LoginOpcodes opcode) : base((short)opcode, PacketHeaderType.AuthSmsg) { }

        public override string ParseOpcode()
        {
            return ((LoginOpcodes)Opcode).ToString();
        }
    }
}
