using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("item_required_target", Schema="mangos")]

    public partial class item_required_target
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("type")] 
		        public byte type { get; set; }
 
        [Column("targetEntry")] 
		        public int targetEntry { get; set; }
    }
}
