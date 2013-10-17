using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("creature_equip_template_raw", Schema="mangos")]

    public partial class creature_equip_template_raw
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("equipmodel1")] 
		        public int equipmodel1 { get; set; }
 
        [Column("equipmodel2")] 
		        public int equipmodel2 { get; set; }
 
        [Column("equipmodel3")] 
		        public int equipmodel3 { get; set; }
 
        [Column("equipinfo1")] 
		        public long equipinfo1 { get; set; }
 
        [Column("equipinfo2")] 
		        public long equipinfo2 { get; set; }
 
        [Column("equipinfo3")] 
		        public long equipinfo3 { get; set; }
 
        [Column("equipslot1")] 
		        public int equipslot1 { get; set; }
 
        [Column("equipslot2")] 
		        public int equipslot2 { get; set; }
 
        [Column("equipslot3")] 
		        public int equipslot3 { get; set; }
    }
}
