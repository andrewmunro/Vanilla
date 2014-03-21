using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("petition_sign", Schema="dbo")]

    public partial class petition_sign
    {
 
        [Column("ownerguid")] 
		        public long ownerguid { get; set; }
 
        [Column("petitionguid")] 
		        public long petitionguid { get; set; }
 
        [Column("playerguid")] 
		        public long playerguid { get; set; }
 
        [Column("player_account")] 
		        public long player_account { get; set; }
    }
}
