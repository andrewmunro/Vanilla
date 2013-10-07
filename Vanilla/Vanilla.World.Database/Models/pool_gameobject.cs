using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("pool_gameobject", Schema="mangos")]

    public partial class pool_gameobject
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("pool_entry")] 
		        public int pool_entry { get; set; }
 
        [Column("description")] 
		        public string description { get; set; }
    }
}
