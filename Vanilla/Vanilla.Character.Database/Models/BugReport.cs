using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

		[Table("bugreport", Schema="dbo")]

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
