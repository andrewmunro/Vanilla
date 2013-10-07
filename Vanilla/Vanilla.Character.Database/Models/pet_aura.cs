using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("pet_aura", Schema="characters")]

    public partial class pet_aura
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("caster_guid")] 
		        public decimal caster_guid { get; set; }
 
        [Column("item_guid")] 
		        public long item_guid { get; set; }
 
        [Column("spell")] 
		        public long spell { get; set; }
 
        [Column("stackcount")] 
		        public long stackcount { get; set; }
 
        [Column("remaincharges")] 
		        public long remaincharges { get; set; }
 
        [Column("basepoints0")] 
		        public int basepoints0 { get; set; }
 
        [Column("basepoints1")] 
		        public int basepoints1 { get; set; }
 
        [Column("basepoints2")] 
		        public int basepoints2 { get; set; }
 
        [Column("periodictime0")] 
		        public long periodictime0 { get; set; }
 
        [Column("periodictime1")] 
		        public long periodictime1 { get; set; }
 
        [Column("periodictime2")] 
		        public long periodictime2 { get; set; }
 
        [Column("maxduration")] 
		        public int maxduration { get; set; }
 
        [Column("remaintime")] 
		        public int remaintime { get; set; }
 
        [Column("effIndexMask")] 
		        public long effIndexMask { get; set; }
    }
}
