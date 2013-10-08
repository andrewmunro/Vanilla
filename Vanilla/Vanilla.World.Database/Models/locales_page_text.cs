using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("locales_page_text", Schema="mangos")]

    public partial class locales_page_text
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("Text_loc1")] 
		        public string Text_loc1 { get; set; }
 
        [Column("Text_loc2")] 
		        public string Text_loc2 { get; set; }
 
        [Column("Text_loc3")] 
		        public string Text_loc3 { get; set; }
 
        [Column("Text_loc4")] 
		        public string Text_loc4 { get; set; }
 
        [Column("Text_loc5")] 
		        public string Text_loc5 { get; set; }
 
        [Column("Text_loc6")] 
		        public string Text_loc6 { get; set; }
 
        [Column("Text_loc7")] 
		        public string Text_loc7 { get; set; }
 
        [Column("Text_loc8")] 
		        public string Text_loc8 { get; set; }
    }
}
