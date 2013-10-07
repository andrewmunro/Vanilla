using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("groups", Schema="characters")]

    public partial class group
    {
 
        [Column("groupId")] 
		        public long groupId { get; set; }
 
        [Column("leaderGuid")] 
		        public long leaderGuid { get; set; }
 
        [Column("mainTank")] 
		        public long mainTank { get; set; }
 
        [Column("mainAssistant")] 
		        public long mainAssistant { get; set; }
 
        [Column("lootMethod")] 
		        public byte lootMethod { get; set; }
 
        [Column("looterGuid")] 
		        public long looterGuid { get; set; }
 
        [Column("lootThreshold")] 
		        public byte lootThreshold { get; set; }
 
        [Column("icon1")] 
		        public long icon1 { get; set; }
 
        [Column("icon2")] 
		        public long icon2 { get; set; }
 
        [Column("icon3")] 
		        public long icon3 { get; set; }
 
        [Column("icon4")] 
		        public long icon4 { get; set; }
 
        [Column("icon5")] 
		        public long icon5 { get; set; }
 
        [Column("icon6")] 
		        public long icon6 { get; set; }
 
        [Column("icon7")] 
		        public long icon7 { get; set; }
 
        [Column("icon8")] 
		        public long icon8 { get; set; }
 
        [Column("isRaid")] 
		        public bool isRaid { get; set; }
    }
}
