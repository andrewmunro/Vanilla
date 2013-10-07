using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("bugreport", Schema="characters")]

    public partial class bugreport
    {
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("type")] 
		        public string type { get; set; }
 
        [Column("content")] 
		        public string content { get; set; }
    }
}
