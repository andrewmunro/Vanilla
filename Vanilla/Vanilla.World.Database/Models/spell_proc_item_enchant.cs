using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("spell_proc_item_enchant", Schema="mangos")]

    public partial class spell_proc_item_enchant
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("ppmRate")] 
		        public float ppmRate { get; set; }
    }
}
