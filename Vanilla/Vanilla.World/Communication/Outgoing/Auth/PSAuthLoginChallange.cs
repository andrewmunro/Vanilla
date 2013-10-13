using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.Auth
{
    using Vanilla.Core.Constants;
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    internal class PSAuthLoginChallange : WorldPacket
    {
        #region Constructors and Destructors

        public PSAuthLoginChallange(SRP6 Srp6)
            : base(LoginOpcodes.AUTH_LOGIN_CHALLENGE)
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

        #endregion
    }
}