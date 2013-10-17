using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("pool_creature", Schema="mangos")]

    public partial class pool_creature
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("pool_entry")] 
		        public int pool_entry { get; set; }
 
        [Column("description")] 
		        public string description { get; set; }
    }
}
