// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PCCharCreate.cs" company="">
//   
// </copyright>
// <summary>
//   The pc char create.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login.Communication.Incoming.Character
{
    using Vanilla.Core.Network;

    /// <summary>
    /// The pc char create.
    /// </summary>
    public sealed class PCCharCreate : PacketReader
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PCCharCreate"/> class.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public PCCharCreate(byte[] data)
            : base(data)
        {
            this.Name = this.ReadCString();
            this.Race = this.ReadByte();
            this.Class = this.ReadByte();

            this.Gender = this.ReadByte();
            this.Skin = this.ReadByte();
            this.Face = this.ReadByte();
            this.HairStyle = this.ReadByte();
            this.HairColor = this.ReadByte();
            this.Accessory = this.ReadByte();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the accessory.
        /// </summary>
        public byte Accessory { get; private set; }

        /// <summary>
        /// Gets the class.
        /// </summary>
        public byte Class { get; private set; }

        /// <summary>
        /// Gets the face.
        /// </summary>
        public byte Face { get; private set; }

        /// <summary>
        /// Gets the gender.
        /// </summary>
        public byte Gender { get; private set; }

        /// <summary>
        /// Gets the hair color.
        /// </summary>
        public byte HairColor { get; private set; }

        /// <summary>
        /// Gets the hair style.
        /// </summary>
        public byte HairStyle { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the race.
        /// </summary>
        public byte Race { get; private set; }

        /// <summary>
        /// Gets the skin.
        /// </summary>
        public byte Skin { get; private set; }

        #endregion
    }
}