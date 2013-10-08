using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("pet_name_generation", Schema="mangos")]

    public partial class pet_name_generation
    {
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("word")] 
		        public string word { get; set; }
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("half")] 
		        public sbyte half { get; set; }
    }
}
