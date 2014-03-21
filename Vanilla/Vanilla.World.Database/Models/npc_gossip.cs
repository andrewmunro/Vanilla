using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("npc_gossip", Schema="dbo")]

    public partial class npc_gossip
    {
 
        [Column("npc_guid")] 
		        public long npc_guid { get; set; }
 
        [Column("textid")] 
		        public int textid { get; set; }
    }
}
