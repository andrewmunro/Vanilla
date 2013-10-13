using Vanilla.Core.Constants;
using Vanilla.Core.Cryptography;
using Vanilla.Core.Extensions;
using Vanilla.Core.Network;
using Vanilla.Core.Network.Packet;
using Vanilla.Core.Opcodes;

namespace Vanilla.Login.Components.Auth.Packets.Outgoing
{
    internal sealed class PSAuthLoginChallange : LoginPacket
    {
        public PSAuthLoginChallange(Authenticator authenticator) : base(LoginOpcodes.AUTH_LOGIN_CHALLENGE)
        {
            WriteNull(1);
            Write((byte)AccountStatus.Ok);
            Write(authenticator.SRP6.B);
            Write((byte)1);
            Write(authenticator.SRP6.g[0]);
            Write((byte)authenticator.SRP6.N.Length);
            Write(authenticator.SRP6.N);
            Write(authenticator.SRP6.salt);
            this.WriteNullByte(17);
        }

        public PSAuthLoginChallange(AccountStatus accountStatus) : base(LoginOpcodes.AUTH_LOGIN_CHALLENGE)
        {
            WriteNull(1);
            Write((byte)accountStatus);
        }
    }
}