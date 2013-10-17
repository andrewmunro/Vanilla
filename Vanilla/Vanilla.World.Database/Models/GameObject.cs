namespace Vanilla.Database.World.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("gameobject", Schema = "mangos")]
    public class GameObject
    {
        [Column("guid")] 
                public long GUID { get; set; }
 
        [Column("id")] 
                public int ID { get; set; }
 
        [Column("map")] 
                public int Map { get; set; }
 
        [Column("position_x")] 
                public float PositionX { get; set; }
 
        [Column("position_y")] 
                public float PositionY { get; set; }
 
        [Column("position_z")] 
                public float PositionZ { get; set; }
 
        [Column("orientation")] 
                public float Orientation { get; set; }
 
        [Column("rotation0")] 
                public float Rotation0 { get; set; }
 
        [Column("rotation1")] 
                public float Rotation1 { get; set; }
 
        [Column("rotation2")] 
                public float Rotation2 { get; set; }
 
        [Column("rotation3")] 
                public float Rotation3 { get; set; }
 
        [Column("spawntimesecs")] 
                public int Spawntimesecs { get; set; }
 
        [Column("animprogress")] 
                public byte Animprogress { get; set; }
 
        [Column("state")] 
                public byte State { get; set; }
    }
}
