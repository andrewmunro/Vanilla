using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("locales_quest", Schema="dbo")]

    public partial class locales_quest
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("Title_loc1")] 
		        public string Title_loc1 { get; set; }
 
        [Column("Title_loc2")] 
		        public string Title_loc2 { get; set; }
 
        [Column("Title_loc3")] 
		        public string Title_loc3 { get; set; }
 
        [Column("Title_loc4")] 
		        public string Title_loc4 { get; set; }
 
        [Column("Title_loc5")] 
		        public string Title_loc5 { get; set; }
 
        [Column("Title_loc6")] 
		        public string Title_loc6 { get; set; }
 
        [Column("Title_loc7")] 
		        public string Title_loc7 { get; set; }
 
        [Column("Title_loc8")] 
		        public string Title_loc8 { get; set; }
 
        [Column("Details_loc1")] 
		        public string Details_loc1 { get; set; }
 
        [Column("Details_loc2")] 
		        public string Details_loc2 { get; set; }
 
        [Column("Details_loc3")] 
		        public string Details_loc3 { get; set; }
 
        [Column("Details_loc4")] 
		        public string Details_loc4 { get; set; }
 
        [Column("Details_loc5")] 
		        public string Details_loc5 { get; set; }
 
        [Column("Details_loc6")] 
		        public string Details_loc6 { get; set; }
 
        [Column("Details_loc7")] 
		        public string Details_loc7 { get; set; }
 
        [Column("Details_loc8")] 
		        public string Details_loc8 { get; set; }
 
        [Column("Objectives_loc1")] 
		        public string Objectives_loc1 { get; set; }
 
        [Column("Objectives_loc2")] 
		        public string Objectives_loc2 { get; set; }
 
        [Column("Objectives_loc3")] 
		        public string Objectives_loc3 { get; set; }
 
        [Column("Objectives_loc4")] 
		        public string Objectives_loc4 { get; set; }
 
        [Column("Objectives_loc5")] 
		        public string Objectives_loc5 { get; set; }
 
        [Column("Objectives_loc6")] 
		        public string Objectives_loc6 { get; set; }
 
        [Column("Objectives_loc7")] 
		        public string Objectives_loc7 { get; set; }
 
        [Column("Objectives_loc8")] 
		        public string Objectives_loc8 { get; set; }
 
        [Column("OfferRewardText_loc1")] 
		        public string OfferRewardText_loc1 { get; set; }
 
        [Column("OfferRewardText_loc2")] 
		        public string OfferRewardText_loc2 { get; set; }
 
        [Column("OfferRewardText_loc3")] 
		        public string OfferRewardText_loc3 { get; set; }
 
        [Column("OfferRewardText_loc4")] 
		        public string OfferRewardText_loc4 { get; set; }
 
        [Column("OfferRewardText_loc5")] 
		        public string OfferRewardText_loc5 { get; set; }
 
        [Column("OfferRewardText_loc6")] 
		        public string OfferRewardText_loc6 { get; set; }
 
        [Column("OfferRewardText_loc7")] 
		        public string OfferRewardText_loc7 { get; set; }
 
        [Column("OfferRewardText_loc8")] 
		        public string OfferRewardText_loc8 { get; set; }
 
        [Column("RequestItemsText_loc1")] 
		        public string RequestItemsText_loc1 { get; set; }
 
        [Column("RequestItemsText_loc2")] 
		        public string RequestItemsText_loc2 { get; set; }
 
        [Column("RequestItemsText_loc3")] 
		        public string RequestItemsText_loc3 { get; set; }
 
        [Column("RequestItemsText_loc4")] 
		        public string RequestItemsText_loc4 { get; set; }
 
        [Column("RequestItemsText_loc5")] 
		        public string RequestItemsText_loc5 { get; set; }
 
        [Column("RequestItemsText_loc6")] 
		        public string RequestItemsText_loc6 { get; set; }
 
        [Column("RequestItemsText_loc7")] 
		        public string RequestItemsText_loc7 { get; set; }
 
        [Column("RequestItemsText_loc8")] 
		        public string RequestItemsText_loc8 { get; set; }
 
        [Column("EndText_loc1")] 
		        public string EndText_loc1 { get; set; }
 
        [Column("EndText_loc2")] 
		        public string EndText_loc2 { get; set; }
 
        [Column("EndText_loc3")] 
		        public string EndText_loc3 { get; set; }
 
        [Column("EndText_loc4")] 
		        public string EndText_loc4 { get; set; }
 
        [Column("EndText_loc5")] 
		        public string EndText_loc5 { get; set; }
 
        [Column("EndText_loc6")] 
		        public string EndText_loc6 { get; set; }
 
        [Column("EndText_loc7")] 
		        public string EndText_loc7 { get; set; }
 
        [Column("EndText_loc8")] 
		        public string EndText_loc8 { get; set; }
 
        [Column("ObjectiveText1_loc1")] 
		        public string ObjectiveText1_loc1 { get; set; }
 
        [Column("ObjectiveText1_loc2")] 
		        public string ObjectiveText1_loc2 { get; set; }
 
        [Column("ObjectiveText1_loc3")] 
		        public string ObjectiveText1_loc3 { get; set; }
 
        [Column("ObjectiveText1_loc4")] 
		        public string ObjectiveText1_loc4 { get; set; }
 
        [Column("ObjectiveText1_loc5")] 
		        public string ObjectiveText1_loc5 { get; set; }
 
        [Column("ObjectiveText1_loc6")] 
		        public string ObjectiveText1_loc6 { get; set; }
 
        [Column("ObjectiveText1_loc7")] 
		        public string ObjectiveText1_loc7 { get; set; }
 
        [Column("ObjectiveText1_loc8")] 
		        public string ObjectiveText1_loc8 { get; set; }
 
        [Column("ObjectiveText2_loc1")] 
		        public string ObjectiveText2_loc1 { get; set; }
 
        [Column("ObjectiveText2_loc2")] 
		        public string ObjectiveText2_loc2 { get; set; }
 
        [Column("ObjectiveText2_loc3")] 
		        public string ObjectiveText2_loc3 { get; set; }
 
        [Column("ObjectiveText2_loc4")] 
		        public string ObjectiveText2_loc4 { get; set; }
 
        [Column("ObjectiveText2_loc5")] 
		        public string ObjectiveText2_loc5 { get; set; }
 
        [Column("ObjectiveText2_loc6")] 
		        public string ObjectiveText2_loc6 { get; set; }
 
        [Column("ObjectiveText2_loc7")] 
		        public string ObjectiveText2_loc7 { get; set; }
 
        [Column("ObjectiveText2_loc8")] 
		        public string ObjectiveText2_loc8 { get; set; }
 
        [Column("ObjectiveText3_loc1")] 
		        public string ObjectiveText3_loc1 { get; set; }
 
        [Column("ObjectiveText3_loc2")] 
		        public string ObjectiveText3_loc2 { get; set; }
 
        [Column("ObjectiveText3_loc3")] 
		        public string ObjectiveText3_loc3 { get; set; }
 
        [Column("ObjectiveText3_loc4")] 
		        public string ObjectiveText3_loc4 { get; set; }
 
        [Column("ObjectiveText3_loc5")] 
		        public string ObjectiveText3_loc5 { get; set; }
 
        [Column("ObjectiveText3_loc6")] 
		        public string ObjectiveText3_loc6 { get; set; }
 
        [Column("ObjectiveText3_loc7")] 
		        public string ObjectiveText3_loc7 { get; set; }
 
        [Column("ObjectiveText3_loc8")] 
		        public string ObjectiveText3_loc8 { get; set; }
 
        [Column("ObjectiveText4_loc1")] 
		        public string ObjectiveText4_loc1 { get; set; }
 
        [Column("ObjectiveText4_loc2")] 
		        public string ObjectiveText4_loc2 { get; set; }
 
        [Column("ObjectiveText4_loc3")] 
		        public string ObjectiveText4_loc3 { get; set; }
 
        [Column("ObjectiveText4_loc4")] 
		        public string ObjectiveText4_loc4 { get; set; }
 
        [Column("ObjectiveText4_loc5")] 
		        public string ObjectiveText4_loc5 { get; set; }
 
        [Column("ObjectiveText4_loc6")] 
		        public string ObjectiveText4_loc6 { get; set; }
 
        [Column("ObjectiveText4_loc7")] 
		        public string ObjectiveText4_loc7 { get; set; }
 
        [Column("ObjectiveText4_loc8")] 
		        public string ObjectiveText4_loc8 { get; set; }
    }
}
