using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("spell_elixir", Schema="dbo")]

    public partial class spell_elixir
    {
 
        [Column("entry")] 
		        public long entry { get; set; }
 
        [Column("mask")] 
		        public byte mask { get; set; }
    }
}
