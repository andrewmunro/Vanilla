using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("gossip_menu_option", Schema="mangos")]

    public partial class gossip_menu_option
    {
 
        [Column("menu_id")] 
		        public int menu_id { get; set; }
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("option_icon")] 
		        public int option_icon { get; set; }
 
        [Column("option_text")] 
		        public string option_text { get; set; }
 
        [Column("option_id")] 
		        public byte option_id { get; set; }
 
        [Column("npc_option_npcflag")] 
		        public long npc_option_npcflag { get; set; }
 
        [Column("action_menu_id")] 
		        public int action_menu_id { get; set; }
 
        [Column("action_poi_id")] 
		        public int action_poi_id { get; set; }
 
        [Column("action_script_id")] 
		        public int action_script_id { get; set; }
 
        [Column("box_coded")] 
		        public byte box_coded { get; set; }
 
        [Column("box_money")] 
		        public long box_money { get; set; }
 
        [Column("box_text")] 
		        public string box_text { get; set; }
 
        [Column("condition_id")] 
		        public int condition_id { get; set; }
    }
}
