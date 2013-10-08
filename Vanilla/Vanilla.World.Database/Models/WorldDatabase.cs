using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Vanilla.World.Database.Models.Mapping;

namespace Vanilla.World.Database.Models
{
    public class WorldDatabase : DbContext
    {
        static WorldDatabase()
        {
            System.Data.Entity.Database.SetInitializer<WorldDatabase>(null);
        }

        public WorldDatabase()
            : base("Name=WorldDatabase")
        {
        }

        public DbSet<areatrigger_involvedrelation> areatrigger_involvedrelation { get; set; }
        public DbSet<areatrigger_tavern> areatrigger_tavern { get; set; }
        public DbSet<areatrigger_teleport> areatrigger_teleport { get; set; }
        public DbSet<battleground_events> battleground_events { get; set; }
        public DbSet<battleground_template> battleground_template { get; set; }
        public DbSet<battlemaster_entry> battlemaster_entry { get; set; }
        public DbSet<command> commands { get; set; }
        public DbSet<condition> conditions { get; set; }
        public DbSet<creature> creatures { get; set; }
        public DbSet<creature_addon> creature_addon { get; set; }
        public DbSet<creature_ai_scripts> creature_ai_scripts { get; set; }
        public DbSet<creature_ai_summons> creature_ai_summons { get; set; }
        public DbSet<creature_ai_texts> creature_ai_texts { get; set; }
        public DbSet<creature_battleground> creature_battleground { get; set; }
        public DbSet<creature_equip_template> creature_equip_template { get; set; }
        public DbSet<creature_equip_template_raw> creature_equip_template_raw { get; set; }
        public DbSet<creature_involvedrelation> creature_involvedrelation { get; set; }
        public DbSet<creature_linking> creature_linking { get; set; }
        public DbSet<creature_linking_template> creature_linking_template { get; set; }
        public DbSet<creature_loot_template> creature_loot_template { get; set; }
        public DbSet<creature_model_info> creature_model_info { get; set; }
        public DbSet<creature_movement> creature_movement { get; set; }
        public DbSet<creature_movement_template> creature_movement_template { get; set; }
        public DbSet<creature_onkill_reputation> creature_onkill_reputation { get; set; }
        public DbSet<creature_questrelation> creature_questrelation { get; set; }
        public DbSet<creature_template> creature_template { get; set; }
        public DbSet<creature_template_addon> creature_template_addon { get; set; }
        public DbSet<creature_template_spells> creature_template_spells { get; set; }
        public DbSet<db_script_string> db_script_string { get; set; }
        public DbSet<dbscripts_on_creature_death> dbscripts_on_creature_death { get; set; }
        public DbSet<dbscripts_on_creature_movement> dbscripts_on_creature_movement { get; set; }
        public DbSet<dbscripts_on_event> dbscripts_on_event { get; set; }
        public DbSet<dbscripts_on_go_template_use> dbscripts_on_go_template_use { get; set; }
        public DbSet<dbscripts_on_go_use> dbscripts_on_go_use { get; set; }
        public DbSet<dbscripts_on_gossip> dbscripts_on_gossip { get; set; }
        public DbSet<dbscripts_on_quest_end> dbscripts_on_quest_end { get; set; }
        public DbSet<dbscripts_on_quest_start> dbscripts_on_quest_start { get; set; }
        public DbSet<dbscripts_on_spell> dbscripts_on_spell { get; set; }
        public DbSet<disenchant_loot_template> disenchant_loot_template { get; set; }
        public DbSet<exploration_basexp> exploration_basexp { get; set; }
        public DbSet<fishing_loot_template> fishing_loot_template { get; set; }
        public DbSet<game_event> game_event { get; set; }
        public DbSet<game_event_creature> game_event_creature { get; set; }
        public DbSet<game_event_creature_data> game_event_creature_data { get; set; }
        public DbSet<game_event_gameobject> game_event_gameobject { get; set; }
        public DbSet<game_event_mail> game_event_mail { get; set; }
        public DbSet<game_event_quest> game_event_quest { get; set; }
        public DbSet<game_graveyard_zone> game_graveyard_zone { get; set; }
        public DbSet<game_tele> game_tele { get; set; }
        public DbSet<game_weather> game_weather { get; set; }
        public DbSet<gameobject> gameobjects { get; set; }
        public DbSet<gameobject_battleground> gameobject_battleground { get; set; }
        public DbSet<gameobject_involvedrelation> gameobject_involvedrelation { get; set; }
        public DbSet<gameobject_loot_template> gameobject_loot_template { get; set; }
        public DbSet<gameobject_questrelation> gameobject_questrelation { get; set; }
        public DbSet<gameobject_template> gameobject_template { get; set; }
        public DbSet<gossip_menu> gossip_menu { get; set; }
        public DbSet<gossip_menu_option> gossip_menu_option { get; set; }
        public DbSet<instance_template> instance_template { get; set; }
        public DbSet<item_enchantment_template> item_enchantment_template { get; set; }
        public DbSet<item_loot_template> item_loot_template { get; set; }
        public DbSet<item_required_target> item_required_target { get; set; }
        public DbSet<item_template> item_template { get; set; }
        public DbSet<locales_creature> locales_creature { get; set; }
        public DbSet<locales_gameobject> locales_gameobject { get; set; }
        public DbSet<locales_gossip_menu_option> locales_gossip_menu_option { get; set; }
        public DbSet<locales_item> locales_item { get; set; }
        public DbSet<locales_npc_text> locales_npc_text { get; set; }
        public DbSet<locales_page_text> locales_page_text { get; set; }
        public DbSet<locales_points_of_interest> locales_points_of_interest { get; set; }
        public DbSet<locales_quest> locales_quest { get; set; }
        public DbSet<mail_loot_template> mail_loot_template { get; set; }
        public DbSet<mangos_string> mangos_string { get; set; }
        public DbSet<npc_gossip> npc_gossip { get; set; }
        public DbSet<npc_text> npc_text { get; set; }
        public DbSet<npc_trainer> npc_trainer { get; set; }
        public DbSet<npc_trainer_template> npc_trainer_template { get; set; }
        public DbSet<npc_vendor> npc_vendor { get; set; }
        public DbSet<npc_vendor_template> npc_vendor_template { get; set; }
        public DbSet<page_text> page_text { get; set; }
        public DbSet<pet_levelstats> pet_levelstats { get; set; }
        public DbSet<pet_name_generation> pet_name_generation { get; set; }
        public DbSet<petcreateinfo_spell> petcreateinfo_spell { get; set; }
        public DbSet<pickpocketing_loot_template> pickpocketing_loot_template { get; set; }
        public DbSet<player_classlevelstats> player_classlevelstats { get; set; }
        public DbSet<player_levelstats> player_levelstats { get; set; }
        public DbSet<player_xp_for_level> player_xp_for_level { get; set; }
        public DbSet<playercreateinfo> playercreateinfoes { get; set; }
        public DbSet<playercreateinfo_action> playercreateinfo_action { get; set; }
        public DbSet<playercreateinfo_item> playercreateinfo_item { get; set; }
        public DbSet<playercreateinfo_spell> playercreateinfo_spell { get; set; }
        public DbSet<points_of_interest> points_of_interest { get; set; }
        public DbSet<pool_creature> pool_creature { get; set; }
        public DbSet<pool_creature_template> pool_creature_template { get; set; }
        public DbSet<pool_gameobject> pool_gameobject { get; set; }
        public DbSet<pool_gameobject_template> pool_gameobject_template { get; set; }
        public DbSet<pool_pool> pool_pool { get; set; }
        public DbSet<pool_template> pool_template { get; set; }
        public DbSet<quest_template> quest_template { get; set; }
        public DbSet<reference_loot_template> reference_loot_template { get; set; }
        public DbSet<reputation_reward_rate> reputation_reward_rate { get; set; }
        public DbSet<reputation_spillover_template> reputation_spillover_template { get; set; }
        public DbSet<reserved_name> reserved_name { get; set; }
        public DbSet<scripted_areatrigger> scripted_areatrigger { get; set; }
        public DbSet<scripted_event> scripted_event { get; set; }
        public DbSet<skill_fishing_base_level> skill_fishing_base_level { get; set; }
        public DbSet<skinning_loot_template> skinning_loot_template { get; set; }
        public DbSet<spell_affect> spell_affect { get; set; }
        public DbSet<spell_area> spell_area { get; set; }
        public DbSet<spell_bonus_data> spell_bonus_data { get; set; }
        public DbSet<spell_chain> spell_chain { get; set; }
        public DbSet<spell_elixir> spell_elixir { get; set; }
        public DbSet<spell_facing> spell_facing { get; set; }
        public DbSet<spell_learn_spell> spell_learn_spell { get; set; }
        public DbSet<spell_linked> spell_linked { get; set; }
        public DbSet<spell_pet_auras> spell_pet_auras { get; set; }
        public DbSet<spell_proc_event> spell_proc_event { get; set; }
        public DbSet<spell_proc_item_enchant> spell_proc_item_enchant { get; set; }
        public DbSet<spell_script_target> spell_script_target { get; set; }
        public DbSet<spell_target_position> spell_target_position { get; set; }
        public DbSet<spell_threat> spell_threat { get; set; }
        public DbSet<transport> transports { get; set; }
        public DbSet<world_template> world_template { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new areatrigger_involvedrelationMap());
            modelBuilder.Configurations.Add(new areatrigger_tavernMap());
            modelBuilder.Configurations.Add(new areatrigger_teleportMap());
            modelBuilder.Configurations.Add(new battleground_eventsMap());
            modelBuilder.Configurations.Add(new battleground_templateMap());
            modelBuilder.Configurations.Add(new battlemaster_entryMap());
            modelBuilder.Configurations.Add(new commandMap());
            modelBuilder.Configurations.Add(new conditionMap());
            modelBuilder.Configurations.Add(new creatureMap());
            modelBuilder.Configurations.Add(new creature_addonMap());
            modelBuilder.Configurations.Add(new creature_ai_scriptsMap());
            modelBuilder.Configurations.Add(new creature_ai_summonsMap());
            modelBuilder.Configurations.Add(new creature_ai_textsMap());
            modelBuilder.Configurations.Add(new creature_battlegroundMap());
            modelBuilder.Configurations.Add(new creature_equip_templateMap());
            modelBuilder.Configurations.Add(new creature_equip_template_rawMap());
            modelBuilder.Configurations.Add(new creature_involvedrelationMap());
            modelBuilder.Configurations.Add(new creature_linkingMap());
            modelBuilder.Configurations.Add(new creature_linking_templateMap());
            modelBuilder.Configurations.Add(new creature_loot_templateMap());
            modelBuilder.Configurations.Add(new creature_model_infoMap());
            modelBuilder.Configurations.Add(new creature_movementMap());
            modelBuilder.Configurations.Add(new creature_movement_templateMap());
            modelBuilder.Configurations.Add(new creature_onkill_reputationMap());
            modelBuilder.Configurations.Add(new creature_questrelationMap());
            modelBuilder.Configurations.Add(new creature_templateMap());
            modelBuilder.Configurations.Add(new creature_template_addonMap());
            modelBuilder.Configurations.Add(new creature_template_spellsMap());
            modelBuilder.Configurations.Add(new db_script_stringMap());
            modelBuilder.Configurations.Add(new dbscripts_on_creature_deathMap());
            modelBuilder.Configurations.Add(new dbscripts_on_creature_movementMap());
            modelBuilder.Configurations.Add(new dbscripts_on_eventMap());
            modelBuilder.Configurations.Add(new dbscripts_on_go_template_useMap());
            modelBuilder.Configurations.Add(new dbscripts_on_go_useMap());
            modelBuilder.Configurations.Add(new dbscripts_on_gossipMap());
            modelBuilder.Configurations.Add(new dbscripts_on_quest_endMap());
            modelBuilder.Configurations.Add(new dbscripts_on_quest_startMap());
            modelBuilder.Configurations.Add(new dbscripts_on_spellMap());
            modelBuilder.Configurations.Add(new disenchant_loot_templateMap());
            modelBuilder.Configurations.Add(new exploration_basexpMap());
            modelBuilder.Configurations.Add(new fishing_loot_templateMap());
            modelBuilder.Configurations.Add(new game_eventMap());
            modelBuilder.Configurations.Add(new game_event_creatureMap());
            modelBuilder.Configurations.Add(new game_event_creature_dataMap());
            modelBuilder.Configurations.Add(new game_event_gameobjectMap());
            modelBuilder.Configurations.Add(new game_event_mailMap());
            modelBuilder.Configurations.Add(new game_event_questMap());
            modelBuilder.Configurations.Add(new game_graveyard_zoneMap());
            modelBuilder.Configurations.Add(new game_teleMap());
            modelBuilder.Configurations.Add(new game_weatherMap());
            modelBuilder.Configurations.Add(new gameobjectMap());
            modelBuilder.Configurations.Add(new gameobject_battlegroundMap());
            modelBuilder.Configurations.Add(new gameobject_involvedrelationMap());
            modelBuilder.Configurations.Add(new gameobject_loot_templateMap());
            modelBuilder.Configurations.Add(new gameobject_questrelationMap());
            modelBuilder.Configurations.Add(new gameobject_templateMap());
            modelBuilder.Configurations.Add(new gossip_menuMap());
            modelBuilder.Configurations.Add(new gossip_menu_optionMap());
            modelBuilder.Configurations.Add(new instance_templateMap());
            modelBuilder.Configurations.Add(new item_enchantment_templateMap());
            modelBuilder.Configurations.Add(new item_loot_templateMap());
            modelBuilder.Configurations.Add(new item_required_targetMap());
            modelBuilder.Configurations.Add(new item_templateMap());
            modelBuilder.Configurations.Add(new locales_creatureMap());
            modelBuilder.Configurations.Add(new locales_gameobjectMap());
            modelBuilder.Configurations.Add(new locales_gossip_menu_optionMap());
            modelBuilder.Configurations.Add(new locales_itemMap());
            modelBuilder.Configurations.Add(new locales_npc_textMap());
            modelBuilder.Configurations.Add(new locales_page_textMap());
            modelBuilder.Configurations.Add(new locales_points_of_interestMap());
            modelBuilder.Configurations.Add(new locales_questMap());
            modelBuilder.Configurations.Add(new mail_loot_templateMap());
            modelBuilder.Configurations.Add(new mangos_stringMap());
            modelBuilder.Configurations.Add(new npc_gossipMap());
            modelBuilder.Configurations.Add(new npc_textMap());
            modelBuilder.Configurations.Add(new npc_trainerMap());
            modelBuilder.Configurations.Add(new npc_trainer_templateMap());
            modelBuilder.Configurations.Add(new npc_vendorMap());
            modelBuilder.Configurations.Add(new npc_vendor_templateMap());
            modelBuilder.Configurations.Add(new page_textMap());
            modelBuilder.Configurations.Add(new pet_levelstatsMap());
            modelBuilder.Configurations.Add(new pet_name_generationMap());
            modelBuilder.Configurations.Add(new petcreateinfo_spellMap());
            modelBuilder.Configurations.Add(new pickpocketing_loot_templateMap());
            modelBuilder.Configurations.Add(new player_classlevelstatsMap());
            modelBuilder.Configurations.Add(new player_levelstatsMap());
            modelBuilder.Configurations.Add(new player_xp_for_levelMap());
            modelBuilder.Configurations.Add(new playercreateinfoMap());
            modelBuilder.Configurations.Add(new playercreateinfo_actionMap());
            modelBuilder.Configurations.Add(new playercreateinfo_itemMap());
            modelBuilder.Configurations.Add(new playercreateinfo_spellMap());
            modelBuilder.Configurations.Add(new points_of_interestMap());
            modelBuilder.Configurations.Add(new pool_creatureMap());
            modelBuilder.Configurations.Add(new pool_creature_templateMap());
            modelBuilder.Configurations.Add(new pool_gameobjectMap());
            modelBuilder.Configurations.Add(new pool_gameobject_templateMap());
            modelBuilder.Configurations.Add(new pool_poolMap());
            modelBuilder.Configurations.Add(new pool_templateMap());
            modelBuilder.Configurations.Add(new quest_templateMap());
            modelBuilder.Configurations.Add(new reference_loot_templateMap());
            modelBuilder.Configurations.Add(new reputation_reward_rateMap());
            modelBuilder.Configurations.Add(new reputation_spillover_templateMap());
            modelBuilder.Configurations.Add(new reserved_nameMap());
            modelBuilder.Configurations.Add(new scripted_areatriggerMap());
            modelBuilder.Configurations.Add(new scripted_eventMap());
            modelBuilder.Configurations.Add(new skill_fishing_base_levelMap());
            modelBuilder.Configurations.Add(new skinning_loot_templateMap());
            modelBuilder.Configurations.Add(new spell_affectMap());
            modelBuilder.Configurations.Add(new spell_areaMap());
            modelBuilder.Configurations.Add(new spell_bonus_dataMap());
            modelBuilder.Configurations.Add(new spell_chainMap());
            modelBuilder.Configurations.Add(new spell_elixirMap());
            modelBuilder.Configurations.Add(new spell_facingMap());
            modelBuilder.Configurations.Add(new spell_learn_spellMap());
            modelBuilder.Configurations.Add(new spell_linkedMap());
            modelBuilder.Configurations.Add(new spell_pet_aurasMap());
            modelBuilder.Configurations.Add(new spell_proc_eventMap());
            modelBuilder.Configurations.Add(new spell_proc_item_enchantMap());
            modelBuilder.Configurations.Add(new spell_script_targetMap());
            modelBuilder.Configurations.Add(new spell_target_positionMap());
            modelBuilder.Configurations.Add(new spell_threatMap());
            modelBuilder.Configurations.Add(new transportMap());
            modelBuilder.Configurations.Add(new world_templateMap());
        }
    }
}
