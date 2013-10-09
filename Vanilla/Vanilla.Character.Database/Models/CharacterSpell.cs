namespace Vanilla.Character.Database.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("character_spell", Schema = "characters")]
    public class CharacterSpell
    {
 
        [Column("guid")] 
                public long GUID { get; set; }
 
        [Column("spell")] 
                public long Spell { get; set; }
 
        [Column("active")] 
                public byte Active { get; set; }
 
        [Column("disabled")] 
                public byte Disabled { get; set; }
    }
}
