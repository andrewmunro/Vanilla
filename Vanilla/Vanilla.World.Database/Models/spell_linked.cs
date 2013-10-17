using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("spell_linked", Schema="mangos")]

    public partial class spell_linked
    {
 
        [Column("entry")] 
		        public long entry { get; set; }
 
        [Column("linked_entry")] 
		        public long linked_entry { get; set; }
 
        [Column("type")] 
		        public long type { get; set; }
 
        [Column("effect_mask")] 
		        public long effect_mask { get; set; }
 
        [Column("comment")] 
		        public string comment { get; set; }
    }
}
