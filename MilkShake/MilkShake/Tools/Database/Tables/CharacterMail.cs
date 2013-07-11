using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants.Game.Mail;
using SQLite;

namespace Milkshake.Tools.Database.Tables
{
    public class CharacterMail
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public MailMessageType MessageType { get; set; }
        public MailStationery Stationery { get; set; }
        public int MailTemplateID { get; set; }
        public int Sender { get; set; }
        public int Reciever { get; set; }
        public String Subject { get; set; }
        public int ItemTextID { get; set; }
        public int Has_Items { get; set; }
        public int Expire_Time { get; set; }
        public int Deliver_Time { get; set; }
        public int Money { get; set; }
        public int COD { get; set; } // CASH ON DELIVERY
        public MailCheckMask Checked { get; set; }
    }
}
