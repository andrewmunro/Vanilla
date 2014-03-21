using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("creature_questrelation", Schema="dbo")]

    public partial class creature_questrelation
    {
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("quest")] 
		        public int quest { get; set; }
    }
}
