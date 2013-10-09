namespace Vanilla.World.Database.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("player_classlevelstats", Schema = "mangos")]
    public class PlayerClassLevelStats
    {
        [Column("class")] 
                public byte Class { get; set; }
 
        [Column("level")] 
                public byte Level { get; set; }
 
        [Column("basehp")] 
                public int BaseHP { get; set; }
 
        [Column("basemana")] 
                public int BaseMana { get; set; }
    }
}
