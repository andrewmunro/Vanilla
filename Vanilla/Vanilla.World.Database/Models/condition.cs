using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("conditions", Schema="dbo")]

    public partial class condition
    {
 
        [Column("condition_entry")] 
		        public int condition_entry { get; set; }
 
        [Column("type")] 
		        public byte type { get; set; }
 
        [Column("value1")] 
		        public int value1 { get; set; }
 
        [Column("value2")] 
		        public int value2 { get; set; }
    }
}
