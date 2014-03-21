using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("item_text", Schema="dbo")]

    public partial class item_text
    {
 
        [Column("id")] 
		        public long id { get; set; }
 
        [Column("text")] 
		        public string text { get; set; }
    }
}
