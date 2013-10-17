using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("mail_items", Schema="characters")]

    public partial class mail_items
    {
 
        [Column("mail_id")] 
		        public int mail_id { get; set; }
 
        [Column("item_guid")] 
		        public int item_guid { get; set; }
 
        [Column("item_template")] 
		        public int item_template { get; set; }
 
        [Column("receiver")] 
		        public long receiver { get; set; }
    }
}
