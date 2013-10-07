using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("character_instance", Schema="characters")]

    public partial class character_instance
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("instance")] 
		        public long instance { get; set; }
 
        [Column("permanent")] 
		        public bool permanent { get; set; }
    }
}
