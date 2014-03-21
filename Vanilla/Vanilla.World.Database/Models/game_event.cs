using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("game_event", Schema="dbo")]

    public partial class game_event
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("start_time")] 
		        public System.DateTime start_time { get; set; }
 
        [Column("end_time")] 
		        public System.DateTime end_time { get; set; }
 
        [Column("occurence")] 
		        public long occurence { get; set; }
 
        [Column("length")] 
		        public long length { get; set; }
 
        [Column("holiday")] 
		        public int holiday { get; set; }
 
        [Column("description")] 
		        public string description { get; set; }
    }
}
