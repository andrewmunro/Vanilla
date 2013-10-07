using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

		[Table("bugreport", Schema="characters")]

	public class BugReport
	{
 
		[Column("id")] 
				public int ID { get; set; }
 
		[Column("type")] 
				public string Type { get; set; }
 
		[Column("content")] 
				public string Content { get; set; }
	}
}
