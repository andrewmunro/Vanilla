using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

		[Table("areatrigger_involvedrelation", Schema="mangos")]

	public class AreatriggerInvolvedrelation
	{
 
		[Column("id")] 
				public int ID { get; set; }
 
		[Column("quest")] 
				public int Quest { get; set; }
	}
}
