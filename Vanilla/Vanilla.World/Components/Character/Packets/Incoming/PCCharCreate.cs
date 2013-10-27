namespace Vanilla.World.Components.Character.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    public sealed class PCCharCreate : PacketReader
    {
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

            //TODO Fix Accessory ReadByte (datastream is not long enough)
            //this.Accessory = this.ReadByte();
        }

        public byte Accessory { get; private set; }

        public byte Class { get; private set; }

        public byte Face { get; private set; }

        public byte Gender { get; private set; }

        public byte HairColor { get; private set; }

        public byte HairStyle { get; private set; }

        public string Name { get; private set; }

        public byte Race { get; private set; }

        public byte Skin { get; private set; }
    }
}