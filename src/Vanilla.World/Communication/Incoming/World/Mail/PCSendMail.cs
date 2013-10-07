using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Incoming.World.Mail
{
    public class PCSendMail : PacketReader
    {
        public PCSendMail(byte[] data) : base(data)
        {
            MailboxGUID = (uint) ReadUInt64();
            Reciever = ReadCString();
            Subject = ReadCString();
            Body = ReadCString();
            ReadUInt32();
            ReadUInt32();
            ItemGUID = ReadUInt32();
            Money = ReadUInt32();
            COD = ReadUInt32();
            ReadUInt64();
            ReadByte();
        }

        public uint COD { get; set; }
        public uint Money { get; set; }
        public uint ItemGUID { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public uint MailboxGUID { get; set; }
        public string Reciever { get; set; }
    }
}
