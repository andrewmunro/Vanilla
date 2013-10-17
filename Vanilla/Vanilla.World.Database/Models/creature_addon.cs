using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("creature_addon", Schema="mangos")]

    public partial class creature_addon
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("mount")] 
		        public int mount { get; set; }
 
        [Column("bytes1")] 
		        public long bytes1 { get; set; }
 
        [Column("b2_0_sheath")] 
		        public byte b2_0_sheath { get; set; }
 
        [Column("b2_1_flags")] 
		        public byte b2_1_flags { get; set; }
 
        [Column("emote")] 
		        public long emote { get; set; }
 
        [Column("moveflags")] 
		        public long moveflags { get; set; }
 
        [Column("auras")] 
		        public string auras { get; set; }
    }
}
