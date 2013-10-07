using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("character_spell_cooldown", Schema="characters")]

    public partial class character_spell_cooldown
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("spell")] 
		        public long spell { get; set; }
 
        [Column("item")] 
		        public long item { get; set; }
 
        [Column("time")] 
		        public decimal time { get; set; }
    }
}
