// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSAuthLoginChallange.cs" company="">
//   
// </copyright>
// <summary>
//   The ps auth login challange.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login.Communication.Outgoing.Auth
{
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    /// <summary>
    /// The ps auth login challange.
    /// </summary>
    internal class PSAuthLoginChallange : ServerPacket
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PSAuthLoginChallange"/> class.
        /// </summary>
        /// <param name="Srp6">
        /// The srp 6.
        /// </param>
        public PSAuthLoginChallange(SRP6 Srp6)
            : base((LoginOpcodes)LoginOpcodes.AUTH_LOGIN_CHALLENGE)
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