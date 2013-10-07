using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("creature_movement", Schema="mangos")]

    public partial class creature_movement
    {
 
        [Column("id")] 
		        public long id { get; set; }
 
        [Column("point")] 
		        public int point { get; set; }
 
        [Column("position_x")] 
		        public float position_x { get; set; }
 
        [Column("position_y")] 
		        public float position_y { get; set; }
 
        [Column("position_z")] 
		        public float position_z { get; set; }
 
        [Column("waittime")] 
		        public long waittime { get; set; }
 
        [Column("script_id")] 
		        public int script_id { get; set; }
 
        [Column("textid1")] 
		        public int textid1 { get; set; }
 
        [Column("textid2")] 
		        public int textid2 { get; set; }
 
        [Column("textid3")] 
		        public int textid3 { get; set; }
 
        [Column("textid4")] 
		        public int textid4 { get; set; }
 
        [Column("textid5")] 
		        public int textid5 { get; set; }
 
        [Column("emote")] 
		        public int emote { get; set; }
 
        [Column("spell")] 
		        public int spell { get; set; }
 
        [Column("wpguid")] 
		        public int wpguid { get; set; }
 
        [Column("orientation")] 
		        public float orientation { get; set; }
 
        [Column("model1")] 
		        public int model1 { get; set; }
 
        [Column("model2")] 
		        public int model2 { get; set; }
    }
}
