using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Login.Database.Models
{

	    [Table("ip_banned", Schema="realmd")]

    public partial class ip_banned
    {
 
        [Column("ip")] 
		        public string ip { get; set; }
 
        [Column("bandate")] 
		        public long bandate { get; set; }
 
        [Column("unbandate")] 
		        public long unbandate { get; set; }
 
        [Column("bannedby")] 
		        public string bannedby { get; set; }
 
        [Column("banreason")] 
		        public string banreason { get; set; }
    }
}
