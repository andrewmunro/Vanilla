using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("npc_vendor_template", Schema="dbo")]

    public partial class npc_vendor_template
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("item")] 
		        public int item { get; set; }
 
        [Column("maxcount")] 
		        public byte maxcount { get; set; }
 
        [Column("incrtime")] 
		        public long incrtime { get; set; }
 
        [Column("condition_id")] 
		        public int condition_id { get; set; }
    }
}
