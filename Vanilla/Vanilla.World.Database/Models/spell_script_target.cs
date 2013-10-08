using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("spell_script_target", Schema="mangos")]

    public partial class spell_script_target
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("type")] 
		        public byte type { get; set; }
 
        [Column("targetEntry")] 
		        public int targetEntry { get; set; }
 
        [Column("inverseEffectMask")] 
		        public int inverseEffectMask { get; set; }
    }
}
