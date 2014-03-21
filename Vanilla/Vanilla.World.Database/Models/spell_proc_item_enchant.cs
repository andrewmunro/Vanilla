using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("spell_proc_item_enchant", Schema="dbo")]

    public partial class spell_proc_item_enchant
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("ppmRate")] 
		        public float ppmRate { get; set; }
    }
}
