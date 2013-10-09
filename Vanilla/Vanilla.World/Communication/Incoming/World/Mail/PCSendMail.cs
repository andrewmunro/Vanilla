namespace Vanilla.World.Communication.Incoming.World.Mail
{
    public class PCSendMail : PacketReader
    {
        #region Constructors and Destructors

        public PCSendMail(byte[] data)
            : base(data)
        {
            this.MailboxGUID = (uint)ReadUInt64();
            this.Reciever = ReadCString();
            this.Subject = ReadCString();
            this.Body = ReadCString();
            ReadUInt32();
            ReadUInt32();
            this.ItemGUID = ReadUInt32();
            this.Money = ReadUInt32();
            this.COD = ReadUInt32();
            ReadUInt64();
            ReadByte();
        }

        #endregion

        #region Public Properties

        public string Body { get; set; }

        public uint COD { get; set; }
        public uint ItemGUID { get; set; }
        public uint MailboxGUID { get; set; }
        public uint Money { get; set; }
        public string Reciever { get; set; }
        public string Subject { get; set; }

        #endregion
    }
}