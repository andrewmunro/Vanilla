namespace Vanilla.Database.Login.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("account_banned", Schema="dbo")]

	public class AccountBanned
	{
 
		[Column("id")] 
				public long Id { get; set; }
 
		[Column("bandate")] 
				public long bandate { get; set; }
 
		[Column("unbandate")] 
				public long unbandate { get; set; }
 
		[Column("bannedby")] 
				public string bannedby { get; set; }
 
		[Column("banreason")] 
				public string banreason { get; set; }
 
		[Column("active")] 
				public byte active { get; set; }
	}
}
