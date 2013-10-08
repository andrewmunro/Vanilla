using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Login.Database.Models
{
    [Table("account", Schema = "realmd")]
    public class Account
    {

        [Column("id")]
        public long ID { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("sha_pass_hash")]
        public string ShaPassHash { get; set; }

        [Column("gmlevel")]
        public byte GmLevel { get; set; }

        [Column("sessionkey")]
        public string SessionKey { get; set; }

        [Column("v")]
        public string V { get; set; }

        [Column("s")]
        public string S { get; set; }

        [Column("email")]
        public string Email { get; set; }

        //[Column("joindate")]
        //public DateTime Joindate { get; set; }

        [Column("last_ip")]
        public string LastIP { get; set; }

        [Column("failed_logins")]
        public long FailedLogins { get; set; }

        [Column("locked")]
        public byte Locked { get; set; }

        //[Column("last_login")]
       // public DateTime LastLogin { get; set; }

        [Column("active_realm_id")]
        public long ActiveRealmID { get; set; }

        [Column("expansion")]
        public byte Expansion { get; set; }

        [Column("mutetime")]
        public decimal MuteTime { get; set; }

        [Column("locale")]
        public byte Locale { get; set; }
    }
}
