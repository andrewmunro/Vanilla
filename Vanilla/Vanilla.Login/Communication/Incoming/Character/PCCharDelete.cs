// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PCCharDelete.cs" company="">
//   
// </copyright>
// <summary>
//   The pc char delete.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login.Communication.Incoming.Character
{
    using Vanilla.Core.Network;

    /// <summary>
    /// The pc char delete.
    /// </summary>
    internal class PCCharDelete : PacketReader
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PCCharDelete"/> class.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public PCCharDelete(byte[] data)
            : base(data)
        {
            var GUID = (int)this.ReadUInt64();

            this.Character = DBCharacters.Characters.First(c => c.GUID == GUID);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the character.
        /// </summary>
        public Character Character { get; private set; }

        #endregion
    }
}