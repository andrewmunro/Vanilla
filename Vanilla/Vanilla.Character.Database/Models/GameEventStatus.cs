namespace Vanilla.Character.Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("game_event_status", Schema="characters")]
    public partial class GameEventStatus
    {
        [Column("event")] 
                public int Event { get; set; }
    }
}
