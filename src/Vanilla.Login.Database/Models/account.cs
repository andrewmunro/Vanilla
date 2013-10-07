using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Login.Database.Models
{

	    [Table("account", Schema="realmd")]

    public partial class account
    {
 
        [Column("id")] 
		        public long id { get; set; }
 
        [Column("username")] 
		        public string username { get; set; }
 
        [Column("sha_pass_hash")] 
		        public string sha_pass_hash { get; set; }
 
        [Column("gmlevel")] 
		        public byte gmlevel { get; set; }
 
        [Column("sessionkey")] 
		        public string sessionkey { get; set; }
 
        [Column("v")] 
		        public string v { get; set; }
 
        [Column("s")] 
		        public string s { get; set; }
 
        [Column("email")] 
		        public string email { get; set; }
 
        [Column("joindate")] 
		        public System.DateTime joindate { get; set; }
 
        [Column("last_ip")] 
		        public string last_ip { get; set; }
 
        [Column("failed_logins")] 
		        public long failed_logins { get; set; }
 
        [Column("locked")] 
		        public byte locked { get; set; }
 
        [Column("last_login")] 
		        public System.DateTime last_login { get; set; }
 
        [Column("active_realm_id")] 
		        public long active_realm_id { get; set; }
 
        [Column("expansion")] 
		        public byte expansion { get; set; }
 
        [Column("mutetime")] 
		        public decimal mutetime { get; set; }
 
        [Column("locale")] 
		        public byte locale { get; set; }
    }
}
