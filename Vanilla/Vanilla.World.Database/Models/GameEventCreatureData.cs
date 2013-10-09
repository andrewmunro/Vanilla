namespace Vanilla.World.Database.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("game_event_creature_data", Schema = "mangos")]
    public class GameEventCreatureData
    {
        [Column("guid")] 
                public long GUID { get; set; }
 
        [Column("entry_id")] 
                public int EntryID { get; set; }
 
        [Column("modelid")] 
                public int Modelid { get; set; }
 
        [Column("equipment_id")] 
                public int EquipmentID { get; set; }
 
        [Column("spell_start")] 
                public int SpellStart { get; set; }
 
        [Column("spell_end")] 
                public int SpellEnd { get; set; }
 
        [Column("event")] 
                public int Event { get; set; }
    }
}
