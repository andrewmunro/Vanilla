using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

		[Table("auction", Schema="characters")]

	public class Auction
	{
 
		[Column("id")] 
				public long ID { get; set; }
 
		[Column("houseid")] 
				public long HouseID { get; set; }
 
		[Column("itemguid")] 
				public long ItemGUID { get; set; }
 
		[Column("item_template")] 
				public long ItemTemplate { get; set; }
 
		[Column("item_count")] 
				public long ItemCount { get; set; }
 
		[Column("item_randompropertyid")] 
				public int ItemRandomPropertyID { get; set; }
 
		[Column("itemowner")] 
				public long ItemOwner { get; set; }
 
		[Column("buyoutprice")] 
				public int BuyOutPrice { get; set; }
 
		[Column("time")] 
				public decimal Time { get; set; }
 
		[Column("buyguid")] 
				public long BuyGUID { get; set; }
 
		[Column("lastbid")] 
				public int LastBid { get; set; }
 
		[Column("startbid")] 
				public int StartBid { get; set; }
 
		[Column("deposit")] 
				public int Deposit { get; set; }
	}
}
