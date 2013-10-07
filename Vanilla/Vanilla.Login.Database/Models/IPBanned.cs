using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Login.Database.Models
{

		[Table("ip_banned", Schema="realmd")]

	public class IPBanned
	{
 
		[Column("ip")] 
				public string Ip { get; set; }
 
		[Column("bandate")] 
				public long Bandate { get; set; }
 
		[Column("unbandate")] 
				public long Unbandate { get; set; }
 
		[Column("bannedby")] 
				public string Bannedby { get; set; }
 
		[Column("banreason")] 
				public string Banreason { get; set; }
	}
}
