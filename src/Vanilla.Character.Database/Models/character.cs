using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("characters", Schema="characters")]

    public partial class character
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("account")] 
		        public long account { get; set; }
 
        [Column("name")] 
		        public string name { get; set; }
 
        [Column("race")] 
		        public byte race { get; set; }
 
        [Column("class")] 
		        public byte @class { get; set; }
 
        [Column("gender")] 
		        public byte gender { get; set; }
 
        [Column("level")] 
		        public byte level { get; set; }
 
        [Column("xp")] 
		        public long xp { get; set; }
 
        [Column("money")] 
		        public long money { get; set; }
 
        [Column("playerBytes")] 
		        public long playerBytes { get; set; }
 
        [Column("playerBytes2")] 
		        public long playerBytes2 { get; set; }
 
        [Column("playerFlags")] 
		        public long playerFlags { get; set; }
 
        [Column("position_x")] 
		        public float position_x { get; set; }
 
        [Column("position_y")] 
		        public float position_y { get; set; }
 
        [Column("position_z")] 
		        public float position_z { get; set; }
 
        [Column("map")] 
		        public long map { get; set; }
 
        [Column("orientation")] 
		        public float orientation { get; set; }
 
        [Column("taximask")] 
		        public string taximask { get; set; }
 
        [Column("online")] 
		        public byte online { get; set; }
 
        [Column("cinematic")] 
		        public byte cinematic { get; set; }
 
        [Column("totaltime")] 
		        public long totaltime { get; set; }
 
        [Column("leveltime")] 
		        public long leveltime { get; set; }
 
        [Column("logout_time")] 
		        public decimal logout_time { get; set; }
 
        [Column("is_logout_resting")] 
		        public byte is_logout_resting { get; set; }
 
        [Column("rest_bonus")] 
		        public float rest_bonus { get; set; }
 
        [Column("resettalents_cost")] 
		        public long resettalents_cost { get; set; }
 
        [Column("resettalents_time")] 
		        public decimal resettalents_time { get; set; }
 
        [Column("trans_x")] 
		        public float trans_x { get; set; }
 
        [Column("trans_y")] 
		        public float trans_y { get; set; }
 
        [Column("trans_z")] 
		        public float trans_z { get; set; }
 
        [Column("trans_o")] 
		        public float trans_o { get; set; }
 
        [Column("transguid")] 
		        public decimal transguid { get; set; }
 
        [Column("extra_flags")] 
		        public long extra_flags { get; set; }
 
        [Column("stable_slots")] 
		        public bool stable_slots { get; set; }
 
        [Column("at_login")] 
		        public long at_login { get; set; }
 
        [Column("zone")] 
		        public long zone { get; set; }
 
        [Column("death_expire_time")] 
		        public decimal death_expire_time { get; set; }
 
        [Column("taxi_path")] 
		        public string taxi_path { get; set; }
 
        [Column("honor_highest_rank")] 
		        public long honor_highest_rank { get; set; }
 
        [Column("honor_standing")] 
		        public long honor_standing { get; set; }
 
        [Column("stored_honor_rating")] 
		        public float stored_honor_rating { get; set; }
 
        [Column("stored_dishonorable_kills")] 
		        public int stored_dishonorable_kills { get; set; }
 
        [Column("stored_honorable_kills")] 
		        public int stored_honorable_kills { get; set; }
 
        [Column("watchedFaction")] 
		        public long watchedFaction { get; set; }
 
        [Column("drunk")] 
		        public int drunk { get; set; }
 
        [Column("health")] 
		        public long health { get; set; }
 
        [Column("power1")] 
		        public long power1 { get; set; }
 
        [Column("power2")] 
		        public long power2 { get; set; }
 
        [Column("power3")] 
		        public long power3 { get; set; }
 
        [Column("power4")] 
		        public long power4 { get; set; }
 
        [Column("power5")] 
		        public long power5 { get; set; }
 
        [Column("exploredZones")] 
		        public string exploredZones { get; set; }
 
        [Column("equipmentCache")] 
		        public string equipmentCache { get; set; }
 
        [Column("ammoId")] 
		        public long ammoId { get; set; }
 
        [Column("actionBars")] 
		        public byte actionBars { get; set; }
 
        [Column("deleteInfos_Account")] 
		        public Nullable<long> deleteInfos_Account { get; set; }
 
        [Column("deleteInfos_Name")] 
		        public string deleteInfos_Name { get; set; }
 
        [Column("deleteDate")] 
		        public Nullable<decimal> deleteDate { get; set; }
    }
}
