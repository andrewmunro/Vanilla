namespace Vanilla.Database.Login.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class RealmListMap : EntityTypeConfiguration<RealmList>
    {
        public RealmListMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.Address)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.RealmBuilds)
                .IsRequired()
                .HasMaxLength(64);

        }
    }
}
