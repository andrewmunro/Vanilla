using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("guild_eventlog", Schema="dbo")]

    public partial class guild_eventlog
    {
 
        [Column("guildid")] 
		        public long guildid { get; set; }
 
        [Column("LogGuid")] 
		        public long LogGuid { get; set; }
 
        [Column("EventType")] 
		        public byte EventType { get; set; }
 
        [Column("PlayerGuid1")] 
		        public long PlayerGuid1 { get; set; }
 
        [Column("PlayerGuid2")] 
		        public long PlayerGuid2 { get; set; }
 
        [Column("NewRank")] 
		        public byte NewRank { get; set; }
 
        [Column("TimeStamp")] 
		        public long TimeStamp { get; set; }
    }
}
