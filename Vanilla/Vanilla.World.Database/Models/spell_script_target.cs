using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("spell_script_target", Schema="dbo")]

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
