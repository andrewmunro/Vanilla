using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("mangos_string", Schema="mangos")]

    public partial class mangos_string
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
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
    }
}
