using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("auction", Schema="characters")]

    public partial class auction
    {
 
        [Column("id")] 
		        public long id { get; set; }
 
        [Column("houseid")] 
		        public long houseid { get; set; }
 
        [Column("itemguid")] 
		        public long itemguid { get; set; }
 
        [Column("item_template")] 
		        public long item_template { get; set; }
 
        [Column("item_count")] 
		        public long item_count { get; set; }
 
        [Column("item_randompropertyid")] 
		        public int item_randompropertyid { get; set; }
 
        [Column("itemowner")] 
		        public long itemowner { get; set; }
 
        [Column("buyoutprice")] 
		        public int buyoutprice { get; set; }
 
        [Column("time")] 
		        public decimal time { get; set; }
 
        [Column("buyguid")] 
		        public long buyguid { get; set; }
 
        [Column("lastbid")] 
		        public int lastbid { get; set; }
 
        [Column("startbid")] 
		        public int startbid { get; set; }
 
        [Column("deposit")] 
		        public int deposit { get; set; }
    }
}
