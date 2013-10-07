using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

        [Table("characters", Schema="characters")]

    public class Character
    {
 
        [Column("guid")] 
                public long GUID { get; set; }
 
        [Column("account")] 
                public long Account { get; set; }
 
        [Column("name")] 
                public string Name { get; set; }
 
        [Column("race")] 
                public byte Race { get; set; }
 
        [Column("class")] 
                public byte Class { get; set; }
 
        [Column("gender")] 
                public byte Gender { get; set; }
 
        [Column("level")] 
                public byte Level { get; set; }
 
        [Column("xp")] 
                public long XP { get; set; }
 
        [Column("money")] 
                public long Money { get; set; }
 
        [Column("playerBytes")] 
                public long PlayerBytes { get; set; }
 
        [Column("playerBytes2")] 
                public long PlayerBytes2 { get; set; }
 
        [Column("playerFlags")] 
                public long PlayerFlags { get; set; }
 
        [Column("position_x")] 
                public float PositionX { get; set; }
 
        [Column("position_y")] 
                public float PositionY { get; set; }
 
        [Column("position_z")] 
                public float PositionZ { get; set; }
 
        [Column("map")] 
                public long Map { get; set; }
 
        [Column("orientation")] 
                public float Orientation { get; set; }
 
        [Column("taximask")] 
                public string TaxiMask { get; set; }
 
        [Column("online")] 
                public byte Online { get; set; }
 
        [Column("cinematic")] 
                public byte Cinematic { get; set; }
 
        [Column("totaltime")] 
                public long TotalTime { get; set; }
 
        [Column("leveltime")] 
                public long LevelTime { get; set; }
 
        [Column("logout_time")] 
                public decimal LogoutTime { get; set; }
 
        [Column("is_logout_resting")] 
                public byte IsLogoutResting { get; set; }
 
        [Column("rest_bonus")] 
                public float RestBonus { get; set; }
 
        [Column("resettalents_cost")] 
                public long ResetTalentsCost { get; set; }
 
        [Column("resettalents_time")] 
                public decimal ResetTalentsTime { get; set; }
 
        [Column("trans_x")] 
                public float TransX { get; set; }
 
        [Column("trans_y")] 
                public float TransY { get; set; }
 
        [Column("trans_z")] 
                public float TransZ { get; set; }
 
        [Column("trans_o")] 
                public float TransO { get; set; }
 
        [Column("transguid")] 
                public decimal TransGUID { get; set; }
 
        [Column("extra_flags")] 
                public long ExtraFlags { get; set; }
 
        [Column("stable_slots")] 
                public bool StableSlots { get; set; }
 
        [Column("at_login")] 
                public long AtLogin { get; set; }
 
        [Column("zone")] 
                public long Zone { get; set; }
 
        [Column("death_expire_time")] 
                public decimal DeathExpireTime { get; set; }
 
        [Column("taxi_path")] 
                public string TaxiPath { get; set; }
 
        [Column("honor_highest_rank")] 
                public long HonorHighestRank { get; set; }
 
        [Column("honor_standing")] 
                public long HonorStanding { get; set; }
 
        [Column("stored_honor_rating")] 
                public float StoredHonorRating { get; set; }
 
        [Column("stored_dishonorable_kills")] 
                public int StoredDishonorableKills { get; set; }
 
        [Column("stored_honorable_kills")] 
                public int StoredHonorableKills { get; set; }
 
        [Column("watchedFaction")] 
                public long WatchedFaction { get; set; }
 
        [Column("drunk")] 
                public int Drunk { get; set; }
 
        [Column("health")] 
                public long Health { get; set; }
 
        [Column("power1")] 
                public long Power1 { get; set; }
 
        [Column("power2")] 
                public long Power2 { get; set; }
 
        [Column("power3")] 
                public long Power3 { get; set; }
 
        [Column("power4")] 
                public long Power4 { get; set; }
 
        [Column("power5")] 
                public long Power5 { get; set; }
 
        [Column("exploredZones")] 
                public string ExploredZones { get; set; }
 
        [Column("equipmentCache")] 
                public string EquipmentCache { get; set; }
 
        [Column("ammoId")] 
                public long AmmoID { get; set; }
 
        [Column("actionBars")] 
                public byte ActionBars { get; set; }
 
        [Column("deleteInfos_Account")] 
                public long? DeleteInfosAccount { get; set; }
 
        [Column("deleteInfos_Name")] 
                public string DeleteInfosName { get; set; }
 
        [Column("deleteDate")] 
                public decimal? DeleteDate { get; set; }
    }
}
