using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("instance_reset", Schema="dbo")]

    public partial class instance_reset
    {
 
        [Column("mapid")] 
		        public long mapid { get; set; }
 
        [Column("resettime")] 
		        public long resettime { get; set; }
    }
}
