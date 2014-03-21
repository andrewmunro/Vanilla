using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("transports", Schema="dbo")]

    public partial class transport
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("name")] 
		        public string name { get; set; }
 
        [Column("period")] 
		        public int period { get; set; }
    }
}
