namespace Vanilla.World.Database.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("game_event_mail", Schema = "mangos")]
    public class GameEventMail
    {
 
        [Column("event")] 
                public short Event { get; set; }
 
        [Column("raceMask")] 
                public int RaceMask { get; set; }
 
        [Column("quest")] 
                public int Quest { get; set; }
 
        [Column("mailTemplateId")] 
                public int MailTemplateId { get; set; }
 
        [Column("senderEntry")] 
                public int SenderEntry { get; set; }
    }
}
