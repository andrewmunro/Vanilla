namespace Vanilla.World.Database.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("gameobject_template", Schema = "mangos")]
    public class GameObjectTemplate
    {
        [Column("entry")] 
                public int Entry { get; set; }
 
        [Column("type")] 
                public byte Type { get; set; }
 
        [Column("displayId")] 
                public int DisplayId { get; set; }
 
        [Column("name")] 
                public string Name { get; set; }
 
        [Column("faction")] 
                public int Faction { get; set; }
 
        [Column("flags")] 
                public long Flags { get; set; }
 
        [Column("size")] 
                public float Size { get; set; }
 
        [Column("data0")] 
                public long Data0 { get; set; }
 
        [Column("data1")] 
                public long Data1 { get; set; }
 
        [Column("data2")] 
                public long Data2 { get; set; }
 
        [Column("data3")] 
                public long Data3 { get; set; }
 
        [Column("data4")] 
                public long Data4 { get; set; }
 
        [Column("data5")] 
                public long Data5 { get; set; }
 
        [Column("data6")] 
                public long Data6 { get; set; }
 
        [Column("data7")] 
                public long Data7 { get; set; }
 
        [Column("data8")] 
                public long Data8 { get; set; }
 
        [Column("data9")] 
                public long Data9 { get; set; }
 
        [Column("data10")] 
                public long Data10 { get; set; }
 
        [Column("data11")] 
                public long Data11 { get; set; }
 
        [Column("data12")] 
                public long Data12 { get; set; }
 
        [Column("data13")] 
                public long Data13 { get; set; }
 
        [Column("data14")] 
                public long Data14 { get; set; }
 
        [Column("data15")] 
                public long Data15 { get; set; }
 
        [Column("data16")] 
                public long Data16 { get; set; }
 
        [Column("data17")] 
                public long Data17 { get; set; }
 
        [Column("data18")] 
                public long Data18 { get; set; }
 
        [Column("data19")] 
                public long Data19 { get; set; }
 
        [Column("data20")] 
                public long Data20 { get; set; }
 
        [Column("data21")] 
                public long Data21 { get; set; }
 
        [Column("data22")] 
                public long Data22 { get; set; }
 
        [Column("data23")] 
                public long Data23 { get; set; }
 
        [Column("mingold")] 
                public int MinGold { get; set; }
 
        [Column("maxgold")] 
                public int MaxGold { get; set; }
 
        [Column("ScriptName")] 
                public string ScriptName { get; set; }
    }
}
