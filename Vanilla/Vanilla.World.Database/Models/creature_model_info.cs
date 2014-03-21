using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("creature_model_info", Schema="dbo")]

    public partial class creature_model_info
    {
 
        [Column("modelid")] 
		        public int modelid { get; set; }
 
        [Column("bounding_radius")] 
		        public float bounding_radius { get; set; }
 
        [Column("combat_reach")] 
		        public float combat_reach { get; set; }
 
        [Column("gender")] 
		        public byte gender { get; set; }
 
        [Column("modelid_other_gender")] 
		        public int modelid_other_gender { get; set; }
 
        [Column("modelid_other_team")] 
		        public int modelid_other_team { get; set; }
    }
}
