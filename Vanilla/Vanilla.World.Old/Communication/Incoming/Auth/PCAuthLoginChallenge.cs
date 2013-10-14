using Vanilla.Core.Network.IO;

namespace Vanilla.World.Communication.Incoming.Auth
{
    #region

    using System;
    using System.Net;

    using Vanilla.Core.Network;

    #endregion

    public class PCAuthLoginChallenge : PacketReader
    {
        #region Fields

        public ushort Build;

        public string Country;

        public byte Error;

        public string GameName;

        public IPAddress IP;

        public string Name;

        public string OS;

        public byte OptCode;

        public string Platform;

        public ushort Size;

        public uint TimeZone;

        public string Version;

        #endregion

        #region Constructors and Destructors

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