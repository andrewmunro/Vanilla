// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PCAuthLoginProof.cs" company="">
//   
// </copyright>
// <summary>
//   The pc auth login proof.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login.Communication.Incoming.Auth
{
    using Vanilla.Core.Network;

    /// <summary>
    /// The pc auth login proof.
    /// </summary>
    public class PCAuthLoginProof : PacketReader
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PCAuthLoginProof"/> class.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public PCAuthLoginProof(byte[] data)
            : base(data)
        {
            this.OptCode = ReadByte();
            this.A = ReadBytes(32);
            this.M1 = ReadBytes(20);

            this.CRC_Hash = ReadBytes(20);
            this.nKeys = ReadByte();
            this.unk = ReadByte();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the a.
        /// </summary>
        public byte[] A { get; private set; }

        /// <summary>
        /// Gets the cr c_ hash.
        /// </summary>
        public byte[] CRC_Hash { get; private set; }

        /// <summary>
        /// Gets the m 1.
        /// </summary>
        public byte[] M1 { get; private set; }

        /// <summary>
        /// Gets the opt code.
        /// </summary>
        public byte OptCode { get; private set; }

        /// <summary>
        /// Gets the n keys.
        /// </summary>
        public byte nKeys { get; private set; }

        /// <summary>
        /// Gets the unk.
        /// </summary>
        public byte unk { get; private set; }

        #endregion
    }
}