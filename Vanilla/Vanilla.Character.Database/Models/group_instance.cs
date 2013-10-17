using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("group_instance", Schema="characters")]

    public partial class group_instance
    {
 
        [Column("leaderGuid")] 
		        public long leaderGuid { get; set; }
 
        [Column("instance")] 
		        public long instance { get; set; }
 
        [Column("permanent")] 
		        public bool permanent { get; set; }
    }
}
