using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("game_event_quest", Schema="mangos")]

    public partial class game_event_quest
    {
 
        [Column("quest")] 
		        public int quest { get; set; }
 
        [Column("event")] 
		        public int @event { get; set; }
    }
}
