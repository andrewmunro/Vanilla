namespace Vanilla.Database.World.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("playercreateinfo_spell", Schema = "mangos")]
    public class PlayerCreateInfoSpell
    {
        [Column("race")] 
                public byte Race { get; set; }
 
        [Column("class")] 
                public byte Class { get; set; }
 
        [Column("Spell")] 
                public int Spell { get; set; }
 
        [Column("Note")] 
                public string Note { get; set; }
    }
}
