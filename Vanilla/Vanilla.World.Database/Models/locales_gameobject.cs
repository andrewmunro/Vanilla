using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("locales_gameobject", Schema="dbo")]

    public partial class locales_gameobject
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("name_loc1")] 
		        public string name_loc1 { get; set; }
 
        [Column("name_loc2")] 
		        public string name_loc2 { get; set; }
 
        [Column("name_loc3")] 
		        public string name_loc3 { get; set; }
 
        [Column("name_loc4")] 
		        public string name_loc4 { get; set; }
 
        [Column("name_loc5")] 
		        public string name_loc5 { get; set; }
 
        [Column("name_loc6")] 
		        public string name_loc6 { get; set; }
 
        [Column("name_loc7")] 
		        public string name_loc7 { get; set; }
 
        [Column("name_loc8")] 
		        public string name_loc8 { get; set; }
    }
}
