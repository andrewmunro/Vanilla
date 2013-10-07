using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("spell_chain", Schema="mangos")]

    public partial class spell_chain
    {
 
        [Column("spell_id")] 
		        public int spell_id { get; set; }
 
        [Column("prev_spell")] 
		        public int prev_spell { get; set; }
 
        [Column("first_spell")] 
		        public int first_spell { get; set; }
 
        [Column("rank")] 
		        public sbyte rank { get; set; }
 
        [Column("req_spell")] 
		        public int req_spell { get; set; }
    }
}
