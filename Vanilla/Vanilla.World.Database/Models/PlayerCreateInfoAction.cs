namespace Vanilla.Database.World.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("playercreateinfo_action", Schema="dbo")]
    public class PlayerCreateInfoAction
    {
        [Column("race")] 
                public byte Race { get; set; }
 
        [Column("class")] 
                public byte Class { get; set; }
 
        [Column("button")] 
                public int Button { get; set; }
 
        [Column("action")] 
                public long Action { get; set; }
 
        [Column("type")] 
                public int Type { get; set; }
    }
}
