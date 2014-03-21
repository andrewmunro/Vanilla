using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("guild_member", Schema="dbo")]

    public partial class guild_member
    {
 
        [Column("guildid")] 
		        public long guildid { get; set; }
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("rank")] 
		        public byte rank { get; set; }
 
        [Column("pnote")] 
		        public string pnote { get; set; }
 
        [Column("offnote")] 
		        public string offnote { get; set; }
    }
}
