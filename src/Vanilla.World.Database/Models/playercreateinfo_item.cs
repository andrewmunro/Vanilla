using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("playercreateinfo_item", Schema="mangos")]

    public partial class playercreateinfo_item
    {
 
        [Column("race")] 
		        public byte race { get; set; }
 
        [Column("class")] 
		        public byte @class { get; set; }
 
        [Column("itemid")] 
		        public int itemid { get; set; }
 
        [Column("amount")] 
		        public byte amount { get; set; }
    }
}
