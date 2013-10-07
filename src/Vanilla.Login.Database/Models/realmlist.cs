using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Login.Database.Models
{

	    [Table("realmlist", Schema="realmd")]

    public partial class realmlist
    {
 
        [Column("id")] 
		        public long id { get; set; }
 
        [Column("name")] 
		        public string name { get; set; }
 
        [Column("address")] 
		        public string address { get; set; }
 
        [Column("port")] 
		        public int port { get; set; }
 
        [Column("icon")] 
		        public byte icon { get; set; }
 
        [Column("realmflags")] 
		        public byte realmflags { get; set; }
 
        [Column("timezone")] 
		        public byte timezone { get; set; }
 
        [Column("allowedSecurityLevel")] 
		        public byte allowedSecurityLevel { get; set; }
 
        [Column("realmbuilds")] 
		        public string realmbuilds { get; set; }
    }
}
