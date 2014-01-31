namespace Vanilla.World.Components.Mail.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    public class PCSendMail : PacketReader
    {
        public PCSendMail(byte[] data)
            : base(data)
        {
            this.MailboxGUID = (uint)this.ReadUInt64();
            this.Reciever = this.ReadCString();
            this.Subject = this.ReadCString();
            this.Body = this.ReadCString();
            this.ReadUInt32();
            this.ReadUInt32();
            this.ItemGUID = this.ReadUInt32();
            this.Money = this.ReadUInt32();
            this.COD = this.ReadUInt32();
            this.ReadUInt64();
            this.ReadByte();
        }

        public string Body { get; set; }

        public uint COD { get; set; }
        public uint ItemGUID { get; set; }
        public uint MailboxGUID { get; set; }
        public uint Money { get; set; }
        public string Reciever { get; set; }
        public string Subject { get; set; }
    }
}