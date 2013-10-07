using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class quest_templateMap : EntityTypeConfiguration<quest_template>
    {
        public quest_templateMap()
        {
            // Primary Key
            this.HasKey(t => t.entry);

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Title)
                .HasMaxLength(65535);

            this.Property(t => t.Details)
                .HasMaxLength(65535);

            this.Property(t => t.Objectives)
                .HasMaxLength(65535);

            this.Property(t => t.OfferRewardText)
                .HasMaxLength(65535);

            this.Property(t => t.RequestItemsText)
                .HasMaxLength(65535);

            this.Property(t => t.EndText)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText1)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText2)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText3)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText4)
                .HasMaxLength(65535);

        }
    }
}
