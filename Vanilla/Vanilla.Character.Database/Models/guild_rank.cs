using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("guild_rank", Schema="characters")]

    public partial class guild_rank
    {
 
        [Column("guildid")] 
		        public long guildid { get; set; }
 
        [Column("rid")] 
		        public long rid { get; set; }
 
        [Column("rname")] 
		        public string rname { get; set; }
 
        [Column("rights")] 
		        public long rights { get; set; }
    }
}
