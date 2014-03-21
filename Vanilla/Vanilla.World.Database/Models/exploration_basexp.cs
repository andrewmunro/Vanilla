using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("exploration_basexp", Schema="dbo")]

    public partial class exploration_basexp
    {
 
        [Column("level")] 
		        public byte level { get; set; }
 
        [Column("basexp")] 
		        public int basexp { get; set; }
    }
}
