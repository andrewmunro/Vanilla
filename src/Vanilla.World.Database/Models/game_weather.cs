using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("game_weather", Schema="mangos")]

    public partial class game_weather
    {
 
        [Column("zone")] 
		        public int zone { get; set; }
 
        [Column("spring_rain_chance")] 
		        public byte spring_rain_chance { get; set; }
 
        [Column("spring_snow_chance")] 
		        public byte spring_snow_chance { get; set; }
 
        [Column("spring_storm_chance")] 
		        public byte spring_storm_chance { get; set; }
 
        [Column("summer_rain_chance")] 
		        public byte summer_rain_chance { get; set; }
 
        [Column("summer_snow_chance")] 
		        public byte summer_snow_chance { get; set; }
 
        [Column("summer_storm_chance")] 
		        public byte summer_storm_chance { get; set; }
 
        [Column("fall_rain_chance")] 
		        public byte fall_rain_chance { get; set; }
 
        [Column("fall_snow_chance")] 
		        public byte fall_snow_chance { get; set; }
 
        [Column("fall_storm_chance")] 
		        public byte fall_storm_chance { get; set; }
 
        [Column("winter_rain_chance")] 
		        public byte winter_rain_chance { get; set; }
 
        [Column("winter_snow_chance")] 
		        public byte winter_snow_chance { get; set; }
 
        [Column("winter_storm_chance")] 
		        public byte winter_storm_chance { get; set; }
    }
}
