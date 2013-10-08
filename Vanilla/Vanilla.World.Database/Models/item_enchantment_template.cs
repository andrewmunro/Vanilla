using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("item_enchantment_template", Schema="mangos")]

    public partial class item_enchantment_template
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("ench")] 
		        public int ench { get; set; }
    }
}
