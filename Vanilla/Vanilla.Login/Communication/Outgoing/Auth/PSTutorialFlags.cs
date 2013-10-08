// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSTutorialFlags.cs" company="">
//   
// </copyright>
// <summary>
//   The ps tutorial flags.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login.Communication.Outgoing.Auth
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    /// <summary>
    /// The ps tutorial flags.
    /// </summary>
    internal class PSTutorialFlags : ServerPacket
    {
        // TODO Write the uint ids of 8 tutorial values
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PSTutorialFlags"/> class.
        /// </summary>
        public PSTutorialFlags()
            : base((WorldOpcodes)WorldOpcodes.SMSG_TUTORIAL_FLAGS)
        {
            this.WriteNullUInt(8);
        }

        #endregion
    }
}