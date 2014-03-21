using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("spell_facing", Schema="dbo")]

    public partial class spell_facing
    {
 
        [Column("entry")] 
		        public long entry { get; set; }
 
        [Column("facingcasterflag")] 
		        public byte facingcasterflag { get; set; }
    }
}
