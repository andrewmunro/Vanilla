using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("creature_involvedrelation", Schema="dbo")]

    public partial class creature_involvedrelation
    {
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("quest")] 
		        public int quest { get; set; }
    }
}
