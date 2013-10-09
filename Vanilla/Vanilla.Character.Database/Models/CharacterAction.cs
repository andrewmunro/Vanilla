namespace Vanilla.Character.Database.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("character_action", Schema = "characters")]
    public class CharacterAction
    {
        [Column("guid")] 
                public long GUID { get; set; }
 
        [Column("button")] 
                public byte Button { get; set; }
 
        [Column("action")] 
                public long Action { get; set; }
 
        [Column("type")] 
                public byte Type { get; set; }
    }
}
