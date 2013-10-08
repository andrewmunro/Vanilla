using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("locales_gossip_menu_option", Schema="mangos")]

    public partial class locales_gossip_menu_option
    {
 
        [Column("menu_id")] 
		        public int menu_id { get; set; }
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("option_text_loc1")] 
		        public string option_text_loc1 { get; set; }
 
        [Column("option_text_loc2")] 
		        public string option_text_loc2 { get; set; }
 
        [Column("option_text_loc3")] 
		        public string option_text_loc3 { get; set; }
 
        [Column("option_text_loc4")] 
		        public string option_text_loc4 { get; set; }
 
        [Column("option_text_loc5")] 
		        public string option_text_loc5 { get; set; }
 
        [Column("option_text_loc6")] 
		        public string option_text_loc6 { get; set; }
 
        [Column("option_text_loc7")] 
		        public string option_text_loc7 { get; set; }
 
        [Column("option_text_loc8")] 
		        public string option_text_loc8 { get; set; }
 
        [Column("box_text_loc1")] 
		        public string box_text_loc1 { get; set; }
 
        [Column("box_text_loc2")] 
		        public string box_text_loc2 { get; set; }
 
        [Column("box_text_loc3")] 
		        public string box_text_loc3 { get; set; }
 
        [Column("box_text_loc4")] 
		        public string box_text_loc4 { get; set; }
 
        [Column("box_text_loc5")] 
		        public string box_text_loc5 { get; set; }
 
        [Column("box_text_loc6")] 
		        public string box_text_loc6 { get; set; }
 
        [Column("box_text_loc7")] 
		        public string box_text_loc7 { get; set; }
 
        [Column("box_text_loc8")] 
		        public string box_text_loc8 { get; set; }
    }
}
