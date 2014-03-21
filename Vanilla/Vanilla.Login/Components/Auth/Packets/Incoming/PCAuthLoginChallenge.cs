namespace Vanilla.Login.Components.Auth.Packets.Incoming
{
    using System.Net;
    using Vanilla.Core.Network.IO;

    public sealed class PCAuthLoginChallenge : PacketReader
    {
        public ushort Build;

        public string Country;

        public byte Error;

        public string GameName;

        public IPAddress IP;

        public string Username;

        public string OS;

        public byte OptCode;

        public string Platform;

        public ushort Size;

        public uint TimeZone;

        public string Version;

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
            this.Username = ReadPascalString(1);
        }
    }
}