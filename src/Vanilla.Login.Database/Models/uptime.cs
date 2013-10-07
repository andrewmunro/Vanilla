using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Login.Database.Models
{

	    [Table("uptime", Schema="realmd")]

    public partial class uptime
    {
 
        [Column("realmid")] 
		        public long realmid { get; set; }
 
        [Column("starttime")] 
		        public decimal starttime { get; set; }
 
        [Column("startstring")] 
		        public string startstring { get; set; }
 
        [Column("uptime")] 
		        public decimal uptime1 { get; set; }
 
        [Column("maxplayers")] 
		        public int maxplayers { get; set; }
    }
}
