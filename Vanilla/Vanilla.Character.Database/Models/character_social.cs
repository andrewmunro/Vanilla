using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("character_social", Schema="dbo")]

    public partial class character_social
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("friend")] 
		        public long friend { get; set; }
 
        [Column("flags")] 
		        public byte flags { get; set; }
    }
}
