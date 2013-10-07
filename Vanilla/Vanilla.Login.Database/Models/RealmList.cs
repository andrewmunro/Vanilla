using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Login.Database.Models
{

		[Table("realmlist", Schema="realmd")]

	public class RealmList
	{
 
		[Column("id")] 
				public long ID { get; set; }
 
		[Column("name")] 
				public string Name { get; set; }
 
		[Column("address")] 
				public string Address { get; set; }
 
		[Column("port")] 
				public int Port { get; set; }
 
		[Column("icon")] 
				public byte Icon { get; set; }
 
		[Column("realmflags")] 
				public byte RealmFlags { get; set; }
 
		[Column("timezone")] 
				public byte TimeZone { get; set; }
 
		[Column("allowedSecurityLevel")] 
				public byte AllowedSecurityLevel { get; set; }
 
		[Column("realmbuilds")] 
				public string RealmBuilds { get; set; }
	}
}
