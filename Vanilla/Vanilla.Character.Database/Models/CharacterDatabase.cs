using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Vanilla.Character.Database.Models.Mapping;

namespace Vanilla.Character.Database.Models
{
    public class CharacterDatabase : DbContext
    {
        static CharacterDatabase()
        {
            System.Data.Entity.Database.SetInitializer<CharacterDatabase>(null);
        }

        public CharacterDatabase()
            : base("Name=charactersContext")
        {
        }

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<BugReport> BugReports { get; set; }
        public DbSet<character_action> CharacterAction { get; set; }
        public DbSet<character_aura> CharacterAura { get; set; }
        public DbSet<character_battleground_data> CharacterBattlegroundData { get; set; }
        public DbSet<character_gifts> CharacterGifts { get; set; }
        public DbSet<character_homebind> CharacterHomebind { get; set; }
        public DbSet<character_honor_cp> CharacterHonorCp { get; set; }
        public DbSet<character_instance> CharacterInstance { get; set; }
        public DbSet<character_inventory> CharacterInventory { get; set; }
        public DbSet<character_pet> CharacterPet { get; set; }
        public DbSet<character_queststatus> CharacterQueststatus { get; set; }
        public DbSet<character_reputation> CharacterReputation { get; set; }
        public DbSet<character_skills> CharacterSkills { get; set; }
        public DbSet<character_social> CharacterSocial { get; set; }
        public DbSet<character_spell> CharacterSpell { get; set; }
        public DbSet<character_spell_cooldown> CharacterSpellCooldown { get; set; }
        public DbSet<character_stats> CharacterStats { get; set; }
        public DbSet<character_ticket> CharacterTicket { get; set; }
        public DbSet<character_tutorial> CharacterTutorial { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<corpse> Corpses { get; set; }
        public DbSet<creature_respawn> CreatureRespawn { get; set; }
        public DbSet<game_event_status> GameEventStatus { get; set; }
        public DbSet<gameobject_respawn> GameobjectRespawn { get; set; }
        public DbSet<group_instance> GroupInstance { get; set; }
        public DbSet<group_member> GroupMember { get; set; }
        public DbSet<group> Groups { get; set; }
        public DbSet<guild> Guilds { get; set; }
        public DbSet<guild_eventlog> GuildEventlog { get; set; }
        public DbSet<guild_member> GuildMember { get; set; }
        public DbSet<guild_rank> GuildRank { get; set; }
        public DbSet<instance> Instances { get; set; }
        public DbSet<instance_reset> InstanceReset { get; set; }
        public DbSet<item_instance> ItemInstance { get; set; }
        public DbSet<item_loot> ItemLoot { get; set; }
        public DbSet<item_text> ItemText { get; set; }
        public DbSet<mail> Mails { get; set; }
        public DbSet<mail_items> MailItems { get; set; }
        public DbSet<pet_aura> PetAura { get; set; }
        public DbSet<pet_spell> PetSpell { get; set; }
        public DbSet<pet_spell_cooldown> PetSpellCooldown { get; set; }
        public DbSet<petition> Petitions { get; set; }
        public DbSet<petition_sign> PetitionSign { get; set; }
        public DbSet<saved_variables> SavedVariables { get; set; }
        public DbSet<world> Worlds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuctionMap());
            modelBuilder.Configurations.Add(new BugreportMap());
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
            modelBuilder.Configurations.Add(new CharacterMap());
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
