namespace Vanilla.Database.Character.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class CharacterSpellMap : EntityTypeConfiguration<CharacterSpell>
    {
        public CharacterSpellMap()
        {
            // Primary Key
            this.HasKey(t => new { t.GUID, t.Spell });

            // Properties
            this.Property(t => t.GUID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Spell)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
