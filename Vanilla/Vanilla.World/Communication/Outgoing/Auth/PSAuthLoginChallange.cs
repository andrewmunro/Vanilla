using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Game.Constants.Login;
using Vanilla.World.Network;
using Vanilla.World.Tools.Cryptography;
using Vanilla.World.Tools.Extensions;

namespace Vanilla.World.Communication.Outgoing.Auth
{
    class PSAuthLoginChallange : ServerPacket
    {
        public PSAuthLoginChallange(SRP6 Srp6) : base((LoginOpcodes) LoginOpcodes.AUTH_LOGIN_CHALLENGE)
        {
            Write((byte)0);
            Write((byte)0);

            if (Srp6 == null)
            {
                Write((byte)AccountStatus.UnknownAccount);
                this.WriteNullByte(6);
            }
            else
            {
                Write((byte)AccountStatus.Ok);
                Write(Srp6.B);
                Write((byte)1);
                Write(Srp6.g[0]);
                Write((byte)Srp6.N.Length);
                Write(Srp6.N);
                Write(Srp6.salt);
                this.WriteNullByte(17);
            }
        }
    }
}
