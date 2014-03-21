using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("group_member", Schema="dbo")]

    public partial class group_member
    {
 
        [Column("groupId")] 
		        public long groupId { get; set; }
 
        [Column("memberGuid")] 
		        public long memberGuid { get; set; }
 
        [Column("assistant")] 
		        public byte assistant { get; set; }
 
        [Column("subgroup")] 
		        public int subgroup { get; set; }
    }
}
