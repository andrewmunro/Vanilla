// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSAuthLoginProof.cs" company="">
//   
// </copyright>
// <summary>
//   The ps auth login proof.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login.Communication.Outgoing.Auth
{
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    /// <summary>
    /// The ps auth login proof.
    /// </summary>
    internal class PSAuthLoginProof : ServerPacket
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PSAuthLoginProof"/> class.
        /// </summary>
        /// <param name="Srp6">
        /// The srp 6.
        /// </param>
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