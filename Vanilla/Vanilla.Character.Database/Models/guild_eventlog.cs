using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("guild_eventlog", Schema="characters")]

    public partial class guild_eventlog
    {
 
        [Column("guildid")] 
		        public long guildid { get; set; }
 
        [Column("LogGuid")] 
		        public long LogGuid { get; set; }
 
        [Column("EventType")] 
		        public bool EventType { get; set; }
 
        [Column("PlayerGuid1")] 
		        public long PlayerGuid1 { get; set; }
 
        [Column("PlayerGuid2")] 
		        public long PlayerGuid2 { get; set; }
 
        [Column("NewRank")] 
		        public byte NewRank { get; set; }
 
        [Column("TimeStamp")] 
		        public decimal TimeStamp { get; set; }
    }
}
