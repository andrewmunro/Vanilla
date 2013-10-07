using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("exploration_basexp", Schema="mangos")]

    public partial class exploration_basexp
    {
 
        [Column("level")] 
		        public sbyte level { get; set; }
 
        [Column("basexp")] 
		        public int basexp { get; set; }
    }
}
