using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("character_inventory", Schema="dbo")]

    public partial class character_inventory
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("bag")] 
		        public long bag { get; set; }
 
        [Column("slot")] 
		        public byte slot { get; set; }
 
        [Column("item")] 
		        public long item { get; set; }
 
        [Column("item_template")] 
		        public long item_template { get; set; }
    }
}
