using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("mail", Schema="characters")]

    public partial class mail
    {
 
        [Column("id")] 
		        public long id { get; set; }
 
        [Column("messageType")] 
		        public byte messageType { get; set; }
 
        [Column("stationery")] 
		        public sbyte stationery { get; set; }
 
        [Column("mailTemplateId")] 
		        public int mailTemplateId { get; set; }
 
        [Column("sender")] 
		        public long sender { get; set; }
 
        [Column("receiver")] 
		        public long receiver { get; set; }
 
        [Column("subject")] 
		        public string subject { get; set; }
 
        [Column("itemTextId")] 
		        public long itemTextId { get; set; }
 
        [Column("has_items")] 
		        public byte has_items { get; set; }
 
        [Column("expire_time")] 
		        public decimal expire_time { get; set; }
 
        [Column("deliver_time")] 
		        public decimal deliver_time { get; set; }
 
        [Column("money")] 
		        public long money { get; set; }
 
        [Column("cod")] 
		        public long cod { get; set; }
 
        [Column("checked")] 
		        public byte @checked { get; set; }
    }
}
