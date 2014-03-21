using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("spell_learn_spell", Schema="dbo")]

    public partial class spell_learn_spell
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("SpellID")] 
		        public int SpellID { get; set; }
 
        [Column("Active")] 
		        public byte Active { get; set; }
    }
}
