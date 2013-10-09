namespace Vanilla.World.Communication.Incoming.Character
{
    using Vanilla.Core.Network;

    public class PCCharCreate : PacketReader
    {
        #region Constructors and Destructors

        public PCCharCreate(byte[] data)
            : base(data)
        {
            this.Name = ReadCString();
            this.Race = ReadByte();
            this.Class = ReadByte();

            this.Gender = ReadByte();
            this.Skin = ReadByte();
            this.Face = ReadByte();
            this.HairStyle = ReadByte();
            this.HairColor = ReadByte();
            this.Accessory = ReadByte();
        }

        #endregion

        #region Public Properties

        public byte Accessory { get; private set; }

        public byte Class { get; private set; }

        public byte Face { get; private set; }
        public byte Gender { get; private set; }
        public byte HairColor { get; private set; }
        public byte HairStyle { get; private set; }
        public string Name { get; private set; }
        public byte Race { get; private set; }
        public byte Skin { get; private set; }

        #endregion
    }
}