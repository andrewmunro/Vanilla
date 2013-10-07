using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("areatrigger_tavern", Schema="mangos")]

    public partial class areatrigger_tavern
    {
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("name")] 
		        public string name { get; set; }
    }
}
