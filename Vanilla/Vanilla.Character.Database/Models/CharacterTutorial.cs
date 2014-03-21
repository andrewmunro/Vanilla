namespace Vanilla.Database.Character.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("character_tutorial", Schema="dbo")]
    public class CharacterTutorial
    {
        [Column("account")] 
                public long Account { get; set; }
 
        [Column("tut0")] 
                public long Tut0 { get; set; }
 
        [Column("tut1")] 
                public long Tut1 { get; set; }
 
        [Column("tut2")] 
                public long Tut2 { get; set; }
 
        [Column("tut3")] 
                public long Tut3 { get; set; }
 
        [Column("tut4")] 
                public long Tut4 { get; set; }
 
        [Column("tut5")] 
                public long Tut5 { get; set; }
 
        [Column("tut6")] 
                public long Tut6 { get; set; }
 
        [Column("tut7")] 
                public long Tut7 { get; set; }
    }
}
