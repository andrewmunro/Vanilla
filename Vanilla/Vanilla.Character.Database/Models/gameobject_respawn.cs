using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("gameobject_respawn", Schema="characters")]

    public partial class gameobject_respawn
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("respawntime")] 
		        public decimal respawntime { get; set; }
 
        [Column("instance")] 
		        public int instance { get; set; }
    }
}
