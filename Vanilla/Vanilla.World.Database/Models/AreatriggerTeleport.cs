using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	[Table("areatrigger_teleport", Schema="mangos")]
	public class AreatriggerTeleport
	{
 
		[Column("id")] 
				public int ID { get; set; }
 
		[Column("name")] 
				public string Name { get; set; }
 
		[Column("required_level")] 
				public byte RequiredLevel { get; set; }
 
		[Column("required_item")] 
				public int RequiredItem { get; set; }
 
		[Column("required_item2")] 
				public int RequiredItem2 { get; set; }
 
		[Column("required_quest_done")] 
				public long RequiredQuestDone { get; set; }
 
		[Column("target_map")] 
				public int TargetMap { get; set; }
 
		[Column("target_position_x")] 
				public float TargetPositionX { get; set; }
 
		[Column("target_position_y")] 
				public float TargetPositionY { get; set; }
 
		[Column("target_position_z")] 
				public float TargetPositionZ { get; set; }
 
		[Column("target_orientation")] 
				public float TargetOrientation { get; set; }
	}
}
