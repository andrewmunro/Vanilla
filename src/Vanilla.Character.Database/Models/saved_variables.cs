using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("saved_variables", Schema="characters")]

    public partial class saved_variables
    {
 
        [Column("NextMaintenanceDate")] 
		        public long NextMaintenanceDate { get; set; }
 
        [Column("cleaning_flags")] 
		        public long cleaning_flags { get; set; }
    }
}
