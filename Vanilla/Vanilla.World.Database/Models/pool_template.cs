using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("pool_template", Schema="dbo")]

    public partial class pool_template
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("max_limit")] 
		        public long max_limit { get; set; }
 
        [Column("description")] 
		        public string description { get; set; }
    }
}
