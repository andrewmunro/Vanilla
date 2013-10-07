using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Vanilla.Character.Database.Models.Mapping;

namespace Vanilla.Character.Database.Models
{
    public partial class CharacterDatabase : DbContext
    {
        static CharacterDatabase()
        {
            Database.SetInitializer<CharacterDatabase>(null);
        }

        public CharacterDatabase()
            : base("Name=charactersContext")
        {
        }

        public DbSet<auction> auctions { get; set; }
        public DbSet<bugreport> bugreports { get; set; }
        public DbSet<character_action> character_action { get; set; }
        public DbSet<character_aura> character_aura { get; set; }
        public DbSet<character_battleground_data> character_battleground_data { get; set; }
        public DbSet<character_gifts> character_gifts { get; set; }
        public DbSet<character_homebind> character_homebind { get; set; }
        public DbSet<character_honor_cp> character_honor_cp { get; set; }
        public DbSet<character_instance> character_instance { get; set; }
        public DbSet<character_inventory> character_inventory { get; set; }
        public DbSet<character_pet> character_pet { get; set; }
        public DbSet<character_queststatus> character_queststatus { get; set; }
        public DbSet<character_reputation> character_reputation { get; set; }
        public DbSet<character_skills> character_skills { get; set; }
        public DbSet<character_social> character_social { get; set; }
        public DbSet<character_spell> character_spell { get; set; }
        public DbSet<character_spell_cooldown> character_spell_cooldown { get; set; }
        public DbSet<character_stats> character_stats { get; set; }
        public DbSet<character_ticket> character_ticket { get; set; }
        public DbSet<character_tutorial> character_tutorial { get; set; }
        public DbSet<character> characters { get; set; }
        public DbSet<corpse> corpses { get; set; }
        public DbSet<creature_respawn> creature_respawn { get; set; }
        public DbSet<game_event_status> game_event_status { get; set; }
        public DbSet<gameobject_respawn> gameobject_respawn { get; set; }
        public DbSet<group_instance> group_instance { get; set; }
        public DbSet<group_member> group_member { get; set; }
        public DbSet<group> groups { get; set; }
        public DbSet<guild> guilds { get; set; }
        public DbSet<guild_eventlog> guild_eventlog { get; set; }
        public DbSet<guild_member> guild_member { get; set; }
        public DbSet<guild_rank> guild_rank { get; set; }
        public DbSet<instance> instances { get; set; }
        public DbSet<instance_reset> instance_reset { get; set; }
        public DbSet<item_instance> item_instance { get; set; }
        public DbSet<item_loot> item_loot { get; set; }
        public DbSet<item_text> item_text { get; set; }
        public DbSet<mail> mails { get; set; }
        public DbSet<mail_items> mail_items { get; set; }
        public DbSet<pet_aura> pet_aura { get; set; }
        public DbSet<pet_spell> pet_spell { get; set; }
        public DbSet<pet_spell_cooldown> pet_spell_cooldown { get; set; }
        public DbSet<petition> petitions { get; set; }
        public DbSet<petition_sign> petition_sign { get; set; }
        public DbSet<saved_variables> saved_variables { get; set; }
        public DbSet<world> worlds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new auctionMap());
            modelBuilder.Configurations.Add(new bugreportMap());
            modelBuilder.Configurations.Add(new character_actionMap());
            modelBuilder.Configurations.Add(new character_auraMap());
            modelBuilder.Configurations.Add(new character_battleground_dataMap());
            modelBuilder.Configurations.Add(new character_giftsMap());
            modelBuilder.Configurations.Add(new character_homebindMap());
            modelBuilder.Configurations.Add(new character_honor_cpMap());
            modelBuilder.Configurations.Add(new character_instanceMap());
            modelBuilder.Configurations.Add(new character_inventoryMap());
            modelBuilder.Configurations.Add(new character_petMap());
            modelBuilder.Configurations.Add(new character_queststatusMap());
            modelBuilder.Configurations.Add(new character_reputationMap());
            modelBuilder.Configurations.Add(new character_skillsMap());
            modelBuilder.Configurations.Add(new character_socialMap());
            modelBuilder.Configurations.Add(new character_spellMap());
            modelBuilder.Configurations.Add(new character_spell_cooldownMap());
            modelBuilder.Configurations.Add(new character_statsMap());
            modelBuilder.Configurations.Add(new character_ticketMap());
            modelBuilder.Configurations.Add(new character_tutorialMap());
            modelBuilder.Configurations.Add(new characterMap());
            modelBuilder.Configurations.Add(new corpseMap());
            modelBuilder.Configurations.Add(new creature_respawnMap());
            modelBuilder.Configurations.Add(new game_event_statusMap());
            modelBuilder.Configurations.Add(new gameobject_respawnMap());
            modelBuilder.Configurations.Add(new group_instanceMap());
            modelBuilder.Configurations.Add(new group_memberMap());
            modelBuilder.Configurations.Add(new groupMap());
            modelBuilder.Configurations.Add(new guildMap());
            modelBuilder.Configurations.Add(new guild_eventlogMap());
            modelBuilder.Configurations.Add(new guild_memberMap());
            modelBuilder.Configurations.Add(new guild_rankMap());
            modelBuilder.Configurations.Add(new instanceMap());
            modelBuilder.Configurations.Add(new instance_resetMap());
            modelBuilder.Configurations.Add(new item_instanceMap());
            modelBuilder.Configurations.Add(new item_lootMap());
            modelBuilder.Configurations.Add(new item_textMap());
            modelBuilder.Configurations.Add(new mailMap());
            modelBuilder.Configurations.Add(new mail_itemsMap());
            modelBuilder.Configurations.Add(new pet_auraMap());
            modelBuilder.Configurations.Add(new pet_spellMap());
            modelBuilder.Configurations.Add(new pet_spell_cooldownMap());
            modelBuilder.Configurations.Add(new petitionMap());
            modelBuilder.Configurations.Add(new petition_signMap());
            modelBuilder.Configurations.Add(new saved_variablesMap());
            modelBuilder.Configurations.Add(new worldMap());
        }
    }
}
