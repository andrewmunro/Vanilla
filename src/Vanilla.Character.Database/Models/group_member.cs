using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("group_member", Schema="characters")]

    public partial class group_member
    {
 
        [Column("groupId")] 
		        public long groupId { get; set; }
 
        [Column("memberGuid")] 
		        public long memberGuid { get; set; }
 
        [Column("assistant")] 
		        public bool assistant { get; set; }
 
        [Column("subgroup")] 
		        public int subgroup { get; set; }
    }
}
