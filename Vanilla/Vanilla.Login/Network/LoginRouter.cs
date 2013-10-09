using Vanilla.Core.Network;
using Vanilla.Core.Opcodes;

namespace Vanilla.Login.Network
{
    public class LoginRouter : PacketRouter<LoginOpcodes, LoginSession, PacketReader>
    {
        public override LoginOpcodes FetchOpcode(PacketReader packet)
        {
            return (LoginOpcodes) packet.ReadByte();
        }
    }
}