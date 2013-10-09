namespace Vanilla.Login.Communication.Outgoing.Auth
{
    using Vanilla.Core.Constants;
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    internal class PSAuthLoginProof : ServerPacket
    {
        #region Constructors and Destructors

        public PSAuthLoginProof(SRP6 Srp6)
            : base(LoginOpcodes.AUTH_LOGIN_PROOF)
        {
            Write((byte)1);
            Write((byte)AccountStatus.Ok);
            Write(Srp6.M2);
            this.WriteNullByte(4);
        }

        #endregion
    }
}