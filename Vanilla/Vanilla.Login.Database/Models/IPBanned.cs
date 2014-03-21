namespace Vanilla.Database.Login.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ip_banned", Schema="dbo")]

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
