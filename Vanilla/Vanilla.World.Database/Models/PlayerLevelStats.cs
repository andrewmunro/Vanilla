namespace Vanilla.Database.World.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("player_levelstats", Schema = "mangos")]
    public class PlayerLevelStats
    {
        [Column("race")] 
                public byte Race { get; set; }
 
        [Column("class")] 
                public byte Class { get; set; }
 
        [Column("level")] 
                public byte Level { get; set; }
 
        [Column("str")] 
                public byte Str { get; set; }
 
        [Column("agi")] 
                public byte Agi { get; set; }
 
        [Column("sta")] 
                public byte Sta { get; set; }
 
        [Column("inte")] 
                public byte Inte { get; set; }
 
        [Column("spi")] 
                public byte Spi { get; set; }
    }
}
