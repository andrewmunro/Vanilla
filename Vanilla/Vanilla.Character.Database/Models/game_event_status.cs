using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("game_event_status", Schema="characters")]

    public partial class game_event_status
    {
 
        [Column("event")] 
		        public int @event { get; set; }
    }
}
