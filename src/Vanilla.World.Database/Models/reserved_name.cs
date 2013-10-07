using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("reserved_name", Schema="mangos")]

    public partial class reserved_name
    {
 
        [Column("name")] 
		        public string name { get; set; }
    }
}
