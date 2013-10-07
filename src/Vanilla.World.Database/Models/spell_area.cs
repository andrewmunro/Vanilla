using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("spell_area", Schema="mangos")]

    public partial class spell_area
    {
 
        [Column("spell")] 
		        public int spell { get; set; }
 
        [Column("area")] 
		        public int area { get; set; }
 
        [Column("quest_start")] 
		        public int quest_start { get; set; }
 
        [Column("quest_start_active")] 
		        public bool quest_start_active { get; set; }
 
        [Column("quest_end")] 
		        public int quest_end { get; set; }
 
        [Column("condition_id")] 
		        public int condition_id { get; set; }
 
        [Column("aura_spell")] 
		        public int aura_spell { get; set; }
 
        [Column("racemask")] 
		        public int racemask { get; set; }
 
        [Column("gender")] 
		        public bool gender { get; set; }
 
        [Column("autocast")] 
		        public bool autocast { get; set; }
    }
}
