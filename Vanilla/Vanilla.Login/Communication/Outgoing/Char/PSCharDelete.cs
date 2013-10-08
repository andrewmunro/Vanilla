// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSCharDelete.cs" company="">
//   
// </copyright>
// <summary>
//   The ps char delete.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login.Communication.Outgoing.Char
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Vanilla.Login.Constants.Login;

    /// <summary>
    /// The ps char delete.
    /// </summary>
    internal class PSCharDelete : ServerPacket
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PSCharDelete"/> class.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        public PSCharDelete(LoginErrorCode code)
            : base((WorldOpcodes)WorldOpcodes.SMSG_CHAR_CREATE)
        {
            Write((byte)code);
        }

        #endregion
    }
}