namespace Vanilla.Database.World.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("game_event_quest", Schema="dbo")]
    public class GameEventQuest
    {
        [Column("quest")] 
                public int Quest { get; set; }
 
        [Column("event")] 
                public int Event { get; set; }
    }
}
