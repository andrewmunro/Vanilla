namespace Vanilla.World.Database.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("creature", Schema = "mangos")]
    public class Creature
    {
        [Column("guid")] 
                public long GUID { get; set; }
 
        [Column("id")] 
                public int ID { get; set; }
 
        [Column("map")] 
                public int Map { get; set; }
 
        [Column("modelid")] 
                public int ModelID { get; set; }
 
        [Column("equipment_id")] 
                public int EquipmentID { get; set; }
 
        [Column("position_x")] 
                public float PositionX { get; set; }
 
        [Column("position_y")] 
                public float PositionY { get; set; }
 
        [Column("position_z")] 
                public float PositionZ { get; set; }
 
        [Column("orientation")] 
                public float Orientation { get; set; }
 
        [Column("spawntimesecs")] 
                public long Spawntimesecs { get; set; }
 
        [Column("spawndist")] 
                public float Spawndist { get; set; }
 
        [Column("currentwaypoint")] 
                public int Currentwaypoint { get; set; }
 
        [Column("curhealth")] 
                public long Curhealth { get; set; }
 
        [Column("curmana")] 
                public long Curmana { get; set; }
 
        [Column("DeathState")] 
                public byte DeathState { get; set; }
 
        [Column("MovementType")] 
                public byte MovementType { get; set; }
    }
}
