using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("creature_template_addon", Schema="dbo")]

    public partial class creature_template_addon
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("mount")] 
		        public int mount { get; set; }
 
        [Column("bytes1")] 
		        public long bytes1 { get; set; }
 
        [Column("b2_0_sheath")] 
		        public byte b2_0_sheath { get; set; }
 
        [Column("b2_1_flags")] 
		        public byte b2_1_flags { get; set; }
 
        [Column("emote")] 
		        public int emote { get; set; }
 
        [Column("moveflags")] 
		        public long moveflags { get; set; }
 
        [Column("auras")] 
		        public string auras { get; set; }
    }
}
