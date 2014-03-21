namespace Vanilla.Database.Character.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("game_event_status", Schema="dbo")]
    public partial class GameEventStatus
    {
        [Column("event")] 
                public int Event { get; set; }
    }
}
