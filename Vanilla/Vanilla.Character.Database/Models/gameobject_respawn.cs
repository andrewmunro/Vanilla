using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("gameobject_respawn", Schema="dbo")]

    public partial class gameobject_respawn
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("respawntime")] 
		        public long respawntime { get; set; }
 
        [Column("instance")] 
		        public int instance { get; set; }
    }
}
