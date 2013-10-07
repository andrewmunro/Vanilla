using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("item_text", Schema="characters")]

    public partial class item_text
    {
 
        [Column("id")] 
		        public long id { get; set; }
 
        [Column("text")] 
		        public string text { get; set; }
    }
}
