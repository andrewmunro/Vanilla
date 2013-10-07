using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Login.Database.Models
{

	    [Table("realmcharacters", Schema="realmd")]

    public partial class realmcharacter
    {
 
        [Column("realmid")] 
		        public long realmid { get; set; }
 
        [Column("acctid")] 
		        public long acctid { get; set; }
 
        [Column("numchars")] 
		        public byte numchars { get; set; }
    }
}
