using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("character_pet", Schema="characters")]

    public partial class character_pet
    {
 
        [Column("id")] 
		        public long id { get; set; }
 
        [Column("entry")] 
		        public long entry { get; set; }
 
        [Column("owner")] 
		        public long owner { get; set; }
 
        [Column("modelid")] 
		        public Nullable<long> modelid { get; set; }
 
        [Column("CreatedBySpell")] 
		        public long CreatedBySpell { get; set; }
 
        [Column("PetType")] 
		        public byte PetType { get; set; }
 
        [Column("level")] 
		        public long level { get; set; }
 
        [Column("exp")] 
		        public long exp { get; set; }
 
        [Column("Reactstate")] 
		        public bool Reactstate { get; set; }
 
        [Column("loyaltypoints")] 
		        public int loyaltypoints { get; set; }
 
        [Column("loyalty")] 
		        public long loyalty { get; set; }
 
        [Column("trainpoint")] 
		        public int trainpoint { get; set; }
 
        [Column("name")] 
		        public string name { get; set; }
 
        [Column("renamed")] 
		        public bool renamed { get; set; }
 
        [Column("slot")] 
		        public long slot { get; set; }
 
        [Column("curhealth")] 
		        public long curhealth { get; set; }
 
        [Column("curmana")] 
		        public long curmana { get; set; }
 
        [Column("curhappiness")] 
		        public long curhappiness { get; set; }
 
        [Column("savetime")] 
		        public decimal savetime { get; set; }
 
        [Column("resettalents_cost")] 
		        public long resettalents_cost { get; set; }
 
        [Column("resettalents_time")] 
		        public decimal resettalents_time { get; set; }
 
        [Column("abdata")] 
		        public string abdata { get; set; }
 
        [Column("teachspelldata")] 
		        public string teachspelldata { get; set; }
    }
}
