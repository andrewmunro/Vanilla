using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

        [Table("mail", Schema="dbo")]

    public class Mail
    {
 
        [Column("id")] 
                public long ID { get; set; }
 
        [Column("messageType")] 
                public byte MessageType { get; set; }
 
        [Column("stationery")] 
                public byte Stationery { get; set; }
 
        [Column("mailTemplateId")] 
                public int MailTemplateId { get; set; }
 
        [Column("sender")] 
                public long Sender { get; set; }
 
        [Column("receiver")] 
                public long Receiver { get; set; }
 
        [Column("subject")] 
                public string Subject { get; set; }
 
        [Column("itemTextId")] 
                public long ItemTextId { get; set; }
 
        [Column("has_items")] 
                public byte HasItems { get; set; }
 
        [Column("expire_time")] 
                public long ExpireTime { get; set; }
 
        [Column("deliver_time")] 
                public long DeliverTime { get; set; }
 
        [Column("money")] 
                public long Money { get; set; }
 
        [Column("cod")] 
                public long Cod { get; set; }
 
        [Column("checked")] 
                public byte Checked { get; set; }
    }
}
