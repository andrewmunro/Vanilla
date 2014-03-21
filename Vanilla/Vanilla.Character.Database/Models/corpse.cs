using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("corpse", Schema="dbo")]

    public partial class corpse
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("player")] 
		        public long player { get; set; }
 
        [Column("position_x")] 
		        public float position_x { get; set; }
 
        [Column("position_y")] 
		        public float position_y { get; set; }
 
        [Column("position_z")] 
		        public float position_z { get; set; }
 
        [Column("orientation")] 
		        public float orientation { get; set; }
 
        [Column("map")] 
		        public long map { get; set; }
 
        [Column("time")] 
		        public long time { get; set; }
 
        [Column("corpse_type")] 
		        public byte corpse_type { get; set; }
 
        [Column("instance")] 
		        public long instance { get; set; }
    }
}
