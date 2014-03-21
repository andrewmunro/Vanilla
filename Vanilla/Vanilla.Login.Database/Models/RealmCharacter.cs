namespace Vanilla.Database.Login.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("realmcharacters", Schema="dbo")]

    public class RealmCharacter
    {
 
        [Column("realmid")] 
		        public long RealmId { get; set; }
 
        [Column("acctid")] 
		        public long AccountID { get; set; }
 
        [Column("numchars")] 
		        public byte NumberOfCharacters { get; set; }
    }
}
