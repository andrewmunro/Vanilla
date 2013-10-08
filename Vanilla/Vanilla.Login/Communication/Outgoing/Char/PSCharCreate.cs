// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSCharCreate.cs" company="">
//   
// </copyright>
// <summary>
//   The ps char create.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login.Communication.Outgoing.Char
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Vanilla.Login.Constants.Login;

    /// <summary>
    /// The ps char create.
    /// </summary>
    internal class PSCharCreate : ServerPacket
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PSCharCreate"/> class.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        public PSCharCreate(LoginErrorCode code)
            : base((WorldOpcodes)WorldOpcodes.SMSG_CHAR_CREATE)
        {
            Write((byte)code);
        }

        #endregion
    }
}