using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("creature_ai_scripts", Schema="mangos")]

    public partial class creature_ai_scripts
    {
 
        [Column("id")] 
		        public long id { get; set; }
 
        [Column("creature_id")] 
		        public long creature_id { get; set; }
 
        [Column("event_type")] 
		        public byte event_type { get; set; }
 
        [Column("event_inverse_phase_mask")] 
		        public int event_inverse_phase_mask { get; set; }
 
        [Column("event_chance")] 
		        public long event_chance { get; set; }
 
        [Column("event_flags")] 
		        public long event_flags { get; set; }
 
        [Column("event_param1")] 
		        public int event_param1 { get; set; }
 
        [Column("event_param2")] 
		        public int event_param2 { get; set; }
 
        [Column("event_param3")] 
		        public int event_param3 { get; set; }
 
        [Column("event_param4")] 
		        public int event_param4 { get; set; }
 
        [Column("action1_type")] 
		        public byte action1_type { get; set; }
 
        [Column("action1_param1")] 
		        public int action1_param1 { get; set; }
 
        [Column("action1_param2")] 
		        public int action1_param2 { get; set; }
 
        [Column("action1_param3")] 
		        public int action1_param3 { get; set; }
 
        [Column("action2_type")] 
		        public byte action2_type { get; set; }
 
        [Column("action2_param1")] 
		        public int action2_param1 { get; set; }
 
        [Column("action2_param2")] 
		        public int action2_param2 { get; set; }
 
        [Column("action2_param3")] 
		        public int action2_param3 { get; set; }
 
        [Column("action3_type")] 
		        public byte action3_type { get; set; }
 
        [Column("action3_param1")] 
		        public int action3_param1 { get; set; }
 
        [Column("action3_param2")] 
		        public int action3_param2 { get; set; }
 
        [Column("action3_param3")] 
		        public int action3_param3 { get; set; }
 
        [Column("comment")] 
		        public string comment { get; set; }
    }
}
