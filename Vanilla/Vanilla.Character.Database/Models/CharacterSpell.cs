namespace Vanilla.Database.Character.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("character_spell", Schema="dbo")]
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
