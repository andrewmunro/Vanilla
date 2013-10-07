using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("item_loot", Schema="characters")]

    public partial class item_loot
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("owner_guid")] 
		        public long owner_guid { get; set; }
 
        [Column("itemid")] 
		        public long itemid { get; set; }
 
        [Column("amount")] 
		        public long amount { get; set; }
 
        [Column("property")] 
		        public int property { get; set; }
    }
}
