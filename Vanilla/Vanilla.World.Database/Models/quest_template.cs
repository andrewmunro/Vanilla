using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("quest_template", Schema="mangos")]

    public partial class quest_template
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("Method")] 
		        public byte Method { get; set; }
 
        [Column("ZoneOrSort")] 
		        public short ZoneOrSort { get; set; }
 
        [Column("MinLevel")] 
		        public byte MinLevel { get; set; }
 
        [Column("QuestLevel")] 
		        public byte QuestLevel { get; set; }
 
        [Column("Type")] 
		        public int Type { get; set; }
 
        [Column("RequiredClasses")] 
		        public int RequiredClasses { get; set; }
 
        [Column("RequiredRaces")] 
		        public int RequiredRaces { get; set; }
 
        [Column("RequiredSkill")] 
		        public int RequiredSkill { get; set; }
 
        [Column("RequiredSkillValue")] 
		        public int RequiredSkillValue { get; set; }
 
        [Column("RepObjectiveFaction")] 
		        public int RepObjectiveFaction { get; set; }
 
        [Column("RepObjectiveValue")] 
		        public int RepObjectiveValue { get; set; }
 
        [Column("RequiredMinRepFaction")] 
		        public int RequiredMinRepFaction { get; set; }
 
        [Column("RequiredMinRepValue")] 
		        public int RequiredMinRepValue { get; set; }
 
        [Column("RequiredMaxRepFaction")] 
		        public int RequiredMaxRepFaction { get; set; }
 
        [Column("RequiredMaxRepValue")] 
		        public int RequiredMaxRepValue { get; set; }
 
        [Column("SuggestedPlayers")] 
		        public byte SuggestedPlayers { get; set; }
 
        [Column("LimitTime")] 
		        public long LimitTime { get; set; }
 
        [Column("QuestFlags")] 
		        public int QuestFlags { get; set; }
 
        [Column("SpecialFlags")] 
		        public byte SpecialFlags { get; set; }
 
        [Column("PrevQuestId")] 
		        public int PrevQuestId { get; set; }
 
        [Column("NextQuestId")] 
		        public int NextQuestId { get; set; }
 
        [Column("ExclusiveGroup")] 
		        public int ExclusiveGroup { get; set; }
 
        [Column("NextQuestInChain")] 
		        public int NextQuestInChain { get; set; }
 
        [Column("SrcItemId")] 
		        public int SrcItemId { get; set; }
 
        [Column("SrcItemCount")] 
		        public byte SrcItemCount { get; set; }
 
        [Column("SrcSpell")] 
		        public int SrcSpell { get; set; }
 
        [Column("Title")] 
		        public string Title { get; set; }
 
        [Column("Details")] 
		        public string Details { get; set; }
 
        [Column("Objectives")] 
		        public string Objectives { get; set; }
 
        [Column("OfferRewardText")] 
		        public string OfferRewardText { get; set; }
 
        [Column("RequestItemsText")] 
		        public string RequestItemsText { get; set; }
 
        [Column("EndText")] 
		        public string EndText { get; set; }
 
        [Column("ObjectiveText1")] 
		        public string ObjectiveText1 { get; set; }
 
        [Column("ObjectiveText2")] 
		        public string ObjectiveText2 { get; set; }
 
        [Column("ObjectiveText3")] 
		        public string ObjectiveText3 { get; set; }
 
        [Column("ObjectiveText4")] 
		        public string ObjectiveText4 { get; set; }
 
        [Column("ReqItemId1")] 
		        public int ReqItemId1 { get; set; }
 
        [Column("ReqItemId2")] 
		        public int ReqItemId2 { get; set; }
 
        [Column("ReqItemId3")] 
		        public int ReqItemId3 { get; set; }
 
        [Column("ReqItemId4")] 
		        public int ReqItemId4 { get; set; }
 
        [Column("ReqItemCount1")] 
		        public int ReqItemCount1 { get; set; }
 
        [Column("ReqItemCount2")] 
		        public int ReqItemCount2 { get; set; }
 
        [Column("ReqItemCount3")] 
		        public int ReqItemCount3 { get; set; }
 
        [Column("ReqItemCount4")] 
		        public int ReqItemCount4 { get; set; }
 
        [Column("ReqSourceId1")] 
		        public int ReqSourceId1 { get; set; }
 
        [Column("ReqSourceId2")] 
		        public int ReqSourceId2 { get; set; }
 
        [Column("ReqSourceId3")] 
		        public int ReqSourceId3 { get; set; }
 
        [Column("ReqSourceId4")] 
		        public int ReqSourceId4 { get; set; }
 
        [Column("ReqSourceCount1")] 
		        public int ReqSourceCount1 { get; set; }
 
        [Column("ReqSourceCount2")] 
		        public int ReqSourceCount2 { get; set; }
 
        [Column("ReqSourceCount3")] 
		        public int ReqSourceCount3 { get; set; }
 
        [Column("ReqSourceCount4")] 
		        public int ReqSourceCount4 { get; set; }
 
        [Column("ReqCreatureOrGOId1")] 
		        public int ReqCreatureOrGOId1 { get; set; }
 
        [Column("ReqCreatureOrGOId2")] 
		        public int ReqCreatureOrGOId2 { get; set; }
 
        [Column("ReqCreatureOrGOId3")] 
		        public int ReqCreatureOrGOId3 { get; set; }
 
        [Column("ReqCreatureOrGOId4")] 
		        public int ReqCreatureOrGOId4 { get; set; }
 
        [Column("ReqCreatureOrGOCount1")] 
		        public int ReqCreatureOrGOCount1 { get; set; }
 
        [Column("ReqCreatureOrGOCount2")] 
		        public int ReqCreatureOrGOCount2 { get; set; }
 
        [Column("ReqCreatureOrGOCount3")] 
		        public int ReqCreatureOrGOCount3 { get; set; }
 
        [Column("ReqCreatureOrGOCount4")] 
		        public int ReqCreatureOrGOCount4 { get; set; }
 
        [Column("ReqSpellCast1")] 
		        public int ReqSpellCast1 { get; set; }
 
        [Column("ReqSpellCast2")] 
		        public int ReqSpellCast2 { get; set; }
 
        [Column("ReqSpellCast3")] 
		        public int ReqSpellCast3 { get; set; }
 
        [Column("ReqSpellCast4")] 
		        public int ReqSpellCast4 { get; set; }
 
        [Column("RewChoiceItemId1")] 
		        public int RewChoiceItemId1 { get; set; }
 
        [Column("RewChoiceItemId2")] 
		        public int RewChoiceItemId2 { get; set; }
 
        [Column("RewChoiceItemId3")] 
		        public int RewChoiceItemId3 { get; set; }
 
        [Column("RewChoiceItemId4")] 
		        public int RewChoiceItemId4 { get; set; }
 
        [Column("RewChoiceItemId5")] 
		        public int RewChoiceItemId5 { get; set; }
 
        [Column("RewChoiceItemId6")] 
		        public int RewChoiceItemId6 { get; set; }
 
        [Column("RewChoiceItemCount1")] 
		        public int RewChoiceItemCount1 { get; set; }
 
        [Column("RewChoiceItemCount2")] 
		        public int RewChoiceItemCount2 { get; set; }
 
        [Column("RewChoiceItemCount3")] 
		        public int RewChoiceItemCount3 { get; set; }
 
        [Column("RewChoiceItemCount4")] 
		        public int RewChoiceItemCount4 { get; set; }
 
        [Column("RewChoiceItemCount5")] 
		        public int RewChoiceItemCount5 { get; set; }
 
        [Column("RewChoiceItemCount6")] 
		        public int RewChoiceItemCount6 { get; set; }
 
        [Column("RewItemId1")] 
		        public int RewItemId1 { get; set; }
 
        [Column("RewItemId2")] 
		        public int RewItemId2 { get; set; }
 
        [Column("RewItemId3")] 
		        public int RewItemId3 { get; set; }
 
        [Column("RewItemId4")] 
		        public int RewItemId4 { get; set; }
 
        [Column("RewItemCount1")] 
		        public int RewItemCount1 { get; set; }
 
        [Column("RewItemCount2")] 
		        public int RewItemCount2 { get; set; }
 
        [Column("RewItemCount3")] 
		        public int RewItemCount3 { get; set; }
 
        [Column("RewItemCount4")] 
		        public int RewItemCount4 { get; set; }
 
        [Column("RewRepFaction1")] 
		        public int RewRepFaction1 { get; set; }
 
        [Column("RewRepFaction2")] 
		        public int RewRepFaction2 { get; set; }
 
        [Column("RewRepFaction3")] 
		        public int RewRepFaction3 { get; set; }
 
        [Column("RewRepFaction4")] 
		        public int RewRepFaction4 { get; set; }
 
        [Column("RewRepFaction5")] 
		        public int RewRepFaction5 { get; set; }
 
        [Column("RewRepValue1")] 
		        public int RewRepValue1 { get; set; }
 
        [Column("RewRepValue2")] 
		        public int RewRepValue2 { get; set; }
 
        [Column("RewRepValue3")] 
		        public int RewRepValue3 { get; set; }
 
        [Column("RewRepValue4")] 
		        public int RewRepValue4 { get; set; }
 
        [Column("RewRepValue5")] 
		        public int RewRepValue5 { get; set; }
 
        [Column("RewOrReqMoney")] 
		        public int RewOrReqMoney { get; set; }
 
        [Column("RewMoneyMaxLevel")] 
		        public long RewMoneyMaxLevel { get; set; }
 
        [Column("RewSpell")] 
		        public int RewSpell { get; set; }
 
        [Column("RewSpellCast")] 
		        public int RewSpellCast { get; set; }
 
        [Column("RewMailTemplateId")] 
		        public int RewMailTemplateId { get; set; }
 
        [Column("RewMailDelaySecs")] 
		        public long RewMailDelaySecs { get; set; }
 
        [Column("PointMapId")] 
		        public int PointMapId { get; set; }
 
        [Column("PointX")] 
		        public float PointX { get; set; }
 
        [Column("PointY")] 
		        public float PointY { get; set; }
 
        [Column("PointOpt")] 
		        public int PointOpt { get; set; }
 
        [Column("DetailsEmote1")] 
		        public int DetailsEmote1 { get; set; }
 
        [Column("DetailsEmote2")] 
		        public int DetailsEmote2 { get; set; }
 
        [Column("DetailsEmote3")] 
		        public int DetailsEmote3 { get; set; }
 
        [Column("DetailsEmote4")] 
		        public int DetailsEmote4 { get; set; }
 
        [Column("DetailsEmoteDelay1")] 
		        public long DetailsEmoteDelay1 { get; set; }
 
        [Column("DetailsEmoteDelay2")] 
		        public long DetailsEmoteDelay2 { get; set; }
 
        [Column("DetailsEmoteDelay3")] 
		        public long DetailsEmoteDelay3 { get; set; }
 
        [Column("DetailsEmoteDelay4")] 
		        public long DetailsEmoteDelay4 { get; set; }
 
        [Column("IncompleteEmote")] 
		        public int IncompleteEmote { get; set; }
 
        [Column("CompleteEmote")] 
		        public int CompleteEmote { get; set; }
 
        [Column("OfferRewardEmote1")] 
		        public int OfferRewardEmote1 { get; set; }
 
        [Column("OfferRewardEmote2")] 
		        public int OfferRewardEmote2 { get; set; }
 
        [Column("OfferRewardEmote3")] 
		        public int OfferRewardEmote3 { get; set; }
 
        [Column("OfferRewardEmote4")] 
		        public int OfferRewardEmote4 { get; set; }
 
        [Column("OfferRewardEmoteDelay1")] 
		        public long OfferRewardEmoteDelay1 { get; set; }
 
        [Column("OfferRewardEmoteDelay2")] 
		        public long OfferRewardEmoteDelay2 { get; set; }
 
        [Column("OfferRewardEmoteDelay3")] 
		        public long OfferRewardEmoteDelay3 { get; set; }
 
        [Column("OfferRewardEmoteDelay4")] 
		        public long OfferRewardEmoteDelay4 { get; set; }
 
        [Column("StartScript")] 
		        public int StartScript { get; set; }
 
        [Column("CompleteScript")] 
		        public int CompleteScript { get; set; }
    }
}
