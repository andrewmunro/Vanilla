using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("petition", Schema="characters")]

    public partial class petition
    {
 
        [Column("ownerguid")] 
		        public long ownerguid { get; set; }
 
        [Column("petitionguid")] 
		        public Nullable<long> petitionguid { get; set; }
 
        [Column("name")] 
		        public string name { get; set; }
    }
}
