using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("game_event_gameobject", Schema="mangos")]

    public partial class game_event_gameobject
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("event")] 
		        public short @event { get; set; }
    }
}
