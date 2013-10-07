using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("gameobject_template", Schema="mangos")]

    public partial class gameobject_template
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("type")] 
		        public byte type { get; set; }
 
        [Column("displayId")] 
		        public int displayId { get; set; }
 
        [Column("name")] 
		        public string name { get; set; }
 
        [Column("faction")] 
		        public int faction { get; set; }
 
        [Column("flags")] 
		        public long flags { get; set; }
 
        [Column("size")] 
		        public float size { get; set; }
 
        [Column("data0")] 
		        public long data0 { get; set; }
 
        [Column("data1")] 
		        public long data1 { get; set; }
 
        [Column("data2")] 
		        public long data2 { get; set; }
 
        [Column("data3")] 
		        public long data3 { get; set; }
 
        [Column("data4")] 
		        public long data4 { get; set; }
 
        [Column("data5")] 
		        public long data5 { get; set; }
 
        [Column("data6")] 
		        public long data6 { get; set; }
 
        [Column("data7")] 
		        public long data7 { get; set; }
 
        [Column("data8")] 
		        public long data8 { get; set; }
 
        [Column("data9")] 
		        public long data9 { get; set; }
 
        [Column("data10")] 
		        public long data10 { get; set; }
 
        [Column("data11")] 
		        public long data11 { get; set; }
 
        [Column("data12")] 
		        public long data12 { get; set; }
 
        [Column("data13")] 
		        public long data13 { get; set; }
 
        [Column("data14")] 
		        public long data14 { get; set; }
 
        [Column("data15")] 
		        public long data15 { get; set; }
 
        [Column("data16")] 
		        public long data16 { get; set; }
 
        [Column("data17")] 
		        public long data17 { get; set; }
 
        [Column("data18")] 
		        public long data18 { get; set; }
 
        [Column("data19")] 
		        public long data19 { get; set; }
 
        [Column("data20")] 
		        public long data20 { get; set; }
 
        [Column("data21")] 
		        public long data21 { get; set; }
 
        [Column("data22")] 
		        public long data22 { get; set; }
 
        [Column("data23")] 
		        public long data23 { get; set; }
 
        [Column("mingold")] 
		        public int mingold { get; set; }
 
        [Column("maxgold")] 
		        public int maxgold { get; set; }
 
        [Column("ScriptName")] 
		        public string ScriptName { get; set; }
    }
}
