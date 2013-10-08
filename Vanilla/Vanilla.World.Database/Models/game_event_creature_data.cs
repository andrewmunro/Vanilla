using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("game_event_creature_data", Schema="mangos")]

    public partial class game_event_creature_data
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("entry_id")] 
		        public int entry_id { get; set; }
 
        [Column("modelid")] 
		        public int modelid { get; set; }
 
        [Column("equipment_id")] 
		        public int equipment_id { get; set; }
 
        [Column("spell_start")] 
		        public int spell_start { get; set; }
 
        [Column("spell_end")] 
		        public int spell_end { get; set; }
 
        [Column("event")] 
		        public int @event { get; set; }
    }
}
