using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("character_spell_cooldown", Schema="dbo")]

    public partial class character_spell_cooldown
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("spell")] 
		        public long spell { get; set; }
 
        [Column("item")] 
		        public long item { get; set; }
 
        [Column("time")] 
		        public long time { get; set; }
    }
}
