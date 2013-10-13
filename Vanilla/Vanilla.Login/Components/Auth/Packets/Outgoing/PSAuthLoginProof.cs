using Vanilla.Core.Constants;
using Vanilla.Core.Cryptography;
using Vanilla.Core.Extensions;
using Vanilla.Core.Network;
using Vanilla.Core.Network.Packet;
using Vanilla.Core.Opcodes;

namespace Vanilla.Login.Components.Auth.Packets.Outgoing
{
    internal class PSAuthLoginProof : LoginPacket
    {
        public PSAuthLoginProof(Authenticator authenticator) : base(LoginOpcodes.AUTH_LOGIN_PROOF)
        {
            Write((byte)AccountStatus.Ok);
            Write(authenticator.SRP6.M2);
            this.WriteNullByte(4);
        }
    }
}