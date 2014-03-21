using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("instance", Schema="dbo")]

    public partial class instance
    {
 
        [Column("id")] 
		        public long id { get; set; }
 
        [Column("map")] 
		        public long map { get; set; }
 
        [Column("resettime")] 
		        public long resettime { get; set; }
 
        [Column("data")] 
		        public string data { get; set; }
    }
}
