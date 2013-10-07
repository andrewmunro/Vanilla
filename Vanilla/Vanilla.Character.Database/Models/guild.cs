using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("guild", Schema="characters")]

    public partial class guild
    {
 
        [Column("guildid")] 
		        public long guildid { get; set; }
 
        [Column("name")] 
		        public string name { get; set; }
 
        [Column("leaderguid")] 
		        public long leaderguid { get; set; }
 
        [Column("EmblemStyle")] 
		        public int EmblemStyle { get; set; }
 
        [Column("EmblemColor")] 
		        public int EmblemColor { get; set; }
 
        [Column("BorderStyle")] 
		        public int BorderStyle { get; set; }
 
        [Column("BorderColor")] 
		        public int BorderColor { get; set; }
 
        [Column("BackgroundColor")] 
		        public int BackgroundColor { get; set; }
 
        [Column("info")] 
		        public string info { get; set; }
 
        [Column("motd")] 
		        public string motd { get; set; }
 
        [Column("createdate")] 
		        public decimal createdate { get; set; }
    }
}
