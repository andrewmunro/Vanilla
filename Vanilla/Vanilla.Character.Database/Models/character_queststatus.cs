using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("character_queststatus", Schema="characters")]

    public partial class character_queststatus
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("quest")] 
		        public long quest { get; set; }
 
        [Column("status")] 
		        public long status { get; set; }
 
        [Column("rewarded")] 
		        public bool rewarded { get; set; }
 
        [Column("explored")] 
		        public bool explored { get; set; }
 
        [Column("timer")] 
		        public decimal timer { get; set; }
 
        [Column("mobcount1")] 
		        public long mobcount1 { get; set; }
 
        [Column("mobcount2")] 
		        public long mobcount2 { get; set; }
 
        [Column("mobcount3")] 
		        public long mobcount3 { get; set; }
 
        [Column("mobcount4")] 
		        public long mobcount4 { get; set; }
 
        [Column("itemcount1")] 
		        public long itemcount1 { get; set; }
 
        [Column("itemcount2")] 
		        public long itemcount2 { get; set; }
 
        [Column("itemcount3")] 
		        public long itemcount3 { get; set; }
 
        [Column("itemcount4")] 
		        public long itemcount4 { get; set; }
    }
}
