using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("item_instance", Schema="characters")]

    public partial class item_instance
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("owner_guid")] 
		        public long owner_guid { get; set; }
 
        [Column("data")] 
		        public string data { get; set; }
    }
}
