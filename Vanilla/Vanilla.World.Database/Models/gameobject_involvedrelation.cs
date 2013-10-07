using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("gameobject_involvedrelation", Schema="mangos")]

    public partial class gameobject_involvedrelation
    {
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("quest")] 
		        public int quest { get; set; }
    }
}
