using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("locales_points_of_interest", Schema="mangos")]

    public partial class locales_points_of_interest
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("icon_name_loc1")] 
		        public string icon_name_loc1 { get; set; }
 
        [Column("icon_name_loc2")] 
		        public string icon_name_loc2 { get; set; }
 
        [Column("icon_name_loc3")] 
		        public string icon_name_loc3 { get; set; }
 
        [Column("icon_name_loc4")] 
		        public string icon_name_loc4 { get; set; }
 
        [Column("icon_name_loc5")] 
		        public string icon_name_loc5 { get; set; }
 
        [Column("icon_name_loc6")] 
		        public string icon_name_loc6 { get; set; }
 
        [Column("icon_name_loc7")] 
		        public string icon_name_loc7 { get; set; }
 
        [Column("icon_name_loc8")] 
		        public string icon_name_loc8 { get; set; }
    }
}
