namespace Vanilla.Database.World.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("playercreateinfo_item", Schema="dbo")]
    public class PlayerCreateInfoItem
    {
 
        [Column("race")] 
                public byte Race { get; set; }
 
        [Column("class")] 
                public byte Class { get; set; }
 
        [Column("itemid")] 
                public int Itemid { get; set; }
 
        [Column("amount")] 
                public byte Amount { get; set; }
    }
}
