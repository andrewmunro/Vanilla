using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("reserved_name", Schema="dbo")]

    public partial class reserved_name
    {
 
        [Column("name")] 
		        public string name { get; set; }
    }
}
