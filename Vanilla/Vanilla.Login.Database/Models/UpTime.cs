namespace Vanilla.Database.Login.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("uptime", Schema="dbo")]

    public class UpTime
    {
 
        [Column("realmid")] 
		        public long RealmID { get; set; }
 
        [Column("starttime")] 
		        public long StartTime { get; set; }
 
        [Column("startstring")] 
		        public string StartString { get; set; }
 
        [Column("uptime")] 
		        public long UpTime1 { get; set; }
 
        [Column("maxplayers")] 
		        public int MaxPlayers { get; set; }
    }
}
