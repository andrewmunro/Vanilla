using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("areatrigger_involvedrelation", Schema="mangos")]

    public partial class areatrigger_involvedrelation
    {
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("quest")] 
		        public int quest { get; set; }
    }
}
