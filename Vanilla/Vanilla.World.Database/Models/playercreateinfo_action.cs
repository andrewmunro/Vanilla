using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("playercreateinfo_action", Schema="mangos")]

    public partial class playercreateinfo_action
    {
 
        [Column("race")] 
		        public byte race { get; set; }
 
        [Column("class")] 
		        public byte @class { get; set; }
 
        [Column("button")] 
		        public int button { get; set; }
 
        [Column("action")] 
		        public long action { get; set; }
 
        [Column("type")] 
		        public int type { get; set; }
    }
}
