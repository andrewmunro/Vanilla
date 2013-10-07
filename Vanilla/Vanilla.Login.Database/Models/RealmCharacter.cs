using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Login.Database.Models
{

	    [Table("realmcharacters", Schema="realmd")]

    public class RealmCharacter
    {
 
        [Column("realmid")] 
		        public long RealmId { get; set; }
 
        [Column("acctid")] 
		        public long AccountID { get; set; }
 
        [Column("numchars")] 
		        public byte NumberOfCharacters { get; set; }
    }
}
