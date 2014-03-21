using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("spell_chain", Schema="dbo")]

    public partial class spell_chain
    {
 
        [Column("spell_id")] 
		        public int spell_id { get; set; }
 
        [Column("prev_spell")] 
		        public int prev_spell { get; set; }
 
        [Column("first_spell")] 
		        public int first_spell { get; set; }
 
        [Column("rank")] 
		        public byte rank { get; set; }
 
        [Column("req_spell")] 
		        public int req_spell { get; set; }
    }
}
