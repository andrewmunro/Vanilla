using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("db_script_string", Schema="mangos")]

    public partial class db_script_string
    {
 
        [Column("entry")] 
		        public long entry { get; set; }
 
        [Column("content_default")] 
		        public string content_default { get; set; }
 
        [Column("content_loc1")] 
		        public string content_loc1 { get; set; }
 
        [Column("content_loc2")] 
		        public string content_loc2 { get; set; }
 
        [Column("content_loc3")] 
		        public string content_loc3 { get; set; }
 
        [Column("content_loc4")] 
		        public string content_loc4 { get; set; }
 
        [Column("content_loc5")] 
		        public string content_loc5 { get; set; }
 
        [Column("content_loc6")] 
		        public string content_loc6 { get; set; }
 
        [Column("content_loc7")] 
		        public string content_loc7 { get; set; }
 
        [Column("content_loc8")] 
		        public string content_loc8 { get; set; }
 
        [Column("sound")] 
		        public int sound { get; set; }
 
        [Column("type")] 
		        public byte type { get; set; }
 
        [Column("language")] 
		        public byte language { get; set; }
 
        [Column("emote")] 
		        public int emote { get; set; }
 
        [Column("comment")] 
		        public string comment { get; set; }
    }
}
