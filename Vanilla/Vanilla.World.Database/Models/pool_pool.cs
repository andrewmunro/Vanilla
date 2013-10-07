using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("pool_pool", Schema="mangos")]

    public partial class pool_pool
    {
 
        [Column("pool_id")] 
		        public int pool_id { get; set; }
 
        [Column("mother_pool")] 
		        public int mother_pool { get; set; }
 
        [Column("chance")] 
		        public float chance { get; set; }
 
        [Column("description")] 
		        public string description { get; set; }
    }
}
