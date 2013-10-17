namespace Vanilla.Database.World.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("playercreateinfo", Schema = "mangos")]
    public class PlayerCreateInfo
    {
        [Column("race")] 
                public byte Race { get; set; }
 
        [Column("class")] 
                public byte Class { get; set; }
 
        [Column("map")] 
                public int Map { get; set; }
 
        [Column("zone")] 
                public int Zone { get; set; }
 
        [Column("position_x")] 
                public float PositionX { get; set; }
 
        [Column("position_y")] 
                public float PositionY { get; set; }
 
        [Column("position_z")] 
                public float PositionZ { get; set; }
 
        [Column("orientation")] 
                public float Orientation { get; set; }
    }
}
