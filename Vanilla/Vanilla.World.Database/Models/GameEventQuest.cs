namespace Vanilla.World.Database.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("game_event_quest", Schema = "mangos")]
    public class GameEventQuest
    {
        [Column("quest")] 
                public int Quest { get; set; }
 
        [Column("event")] 
                public int Event { get; set; }
    }
}
