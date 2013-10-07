using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("instance", Schema="characters")]

    public partial class instance
    {
 
        [Column("id")] 
		        public long id { get; set; }
 
        [Column("map")] 
		        public long map { get; set; }
 
        [Column("resettime")] 
		        public decimal resettime { get; set; }
 
        [Column("data")] 
		        public string data { get; set; }
    }
}
