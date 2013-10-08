// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PCAuthLoginChallenge.cs" company="">
//   
// </copyright>
// <summary>
//   The pc auth login challenge.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login.Communication.Incoming.Auth
{
    using System;
    using System.Net;

    using Vanilla.Core.Network;

    /// <summary>
    /// The pc auth login challenge.
    /// </summary>
    public class PCAuthLoginChallenge : PacketReader
    {
        #region Fields

        /// <summary>
        /// The build.
        /// </summary>
        public ushort Build;

        /// <summary>
        /// The country.
        /// </summary>
        public string Country;

        /// <summary>
        /// The error.
        /// </summary>
        public byte Error;

        /// <summary>
        /// The game name.
        /// </summary>
        public string GameName;

        /// <summary>
        /// The ip.
        /// </summary>
        public IPAddress IP;

        /// <summary>
        /// The name.
        /// </summary>
        public string Name;

        /// <summary>
        /// The os.
        /// </summary>
        public string OS;

        /// <summary>
        /// The opt code.
        /// </summary>
        public byte OptCode;

        /// <summary>
        /// The platform.
        /// </summary>
        public string Platform;

        /// <summary>
        /// The size.
        /// </summary>
        public ushort Size;

        /// <summary>
        /// The time zone.
        /// </summary>
        public uint TimeZone;

        /// <summary>
        /// The version.
        /// </summary>
        public string Version;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PCAuthLoginChallenge"/> class.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public PCAuthLoginChallenge(byte[] data)
            : base(data)
        {
            this.OptCode = ReadByte();
            this.Error = ReadByte();
            this.Size = ReadUInt16();

            this.GameName = ReadStringReversed(4);
            this.Version = ReadByte().ToString() + '.' + ReadByte().ToString() + '.' + ReadByte().ToString();

            this.Build = ReadUInt16();
            this.Platform = ReadStringReversed(4);
            this.OS = ReadStringReversed(4);
            this.Country = ReadStringReversed(4);

            this.TimeZone = ReadUInt32();
            this.IP = ReadIpAddress();
            this.Name = ReadPascalString(1);
        }

        #endregion
    }
}