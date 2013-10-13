using Vanilla.Core.Network.IO;

namespace Vanilla.Login.Network
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    public class LoginRouter : Router<LoginOpcodes, LoginSession, PacketReader>
    {
        public override LoginOpcodes FetchOpcode(PacketReader packet)
        {
            return (LoginOpcodes)packet.ReadByte();
        }
    }
}