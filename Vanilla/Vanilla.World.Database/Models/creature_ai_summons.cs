using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("creature_ai_summons", Schema="dbo")]

    public partial class creature_ai_summons
    {
 
        [Column("id")] 
		        public long id { get; set; }
 
        [Column("position_x")] 
		        public float position_x { get; set; }
 
        [Column("position_y")] 
		        public float position_y { get; set; }
 
        [Column("position_z")] 
		        public float position_z { get; set; }
 
        [Column("orientation")] 
		        public float orientation { get; set; }
 
        [Column("spawntimesecs")] 
		        public long spawntimesecs { get; set; }
 
        [Column("comment")] 
		        public string comment { get; set; }
    }
}
