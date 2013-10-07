using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("spell_elixir", Schema="mangos")]

    public partial class spell_elixir
    {
 
        [Column("entry")] 
		        public long entry { get; set; }
 
        [Column("mask")] 
		        public bool mask { get; set; }
    }
}
