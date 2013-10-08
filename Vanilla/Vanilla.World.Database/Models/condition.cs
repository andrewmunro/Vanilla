using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("conditions", Schema="mangos")]

    public partial class condition
    {
 
        [Column("condition_entry")] 
		        public int condition_entry { get; set; }
 
        [Column("type")] 
		        public sbyte type { get; set; }
 
        [Column("value1")] 
		        public int value1 { get; set; }
 
        [Column("value2")] 
		        public int value2 { get; set; }
    }
}
