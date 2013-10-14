using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.Auth
{
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    internal class PSAuthLoginProof : WorldPacket
    {
        #region Constructors and Destructors

        public PSAuthLoginProof(SRP6 Srp6)
            : base((LoginOpcodes)LoginOpcodes.AUTH_LOGIN_PROOF)
        {
            Write((byte)1);
            Write((byte)AccountStatus.Ok);
            Write(Srp6.M2);
            this.WriteNullByte(4);
        }

        #endregion
    }
}