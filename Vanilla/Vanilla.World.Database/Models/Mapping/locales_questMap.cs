using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class locales_questMap : EntityTypeConfiguration<locales_quest>
    {
        public locales_questMap()
        {
            // Primary Key
            this.HasKey(t => t.entry);

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Title_loc1)
                .HasMaxLength(65535);

            this.Property(t => t.Title_loc2)
                .HasMaxLength(65535);

            this.Property(t => t.Title_loc3)
                .HasMaxLength(65535);

            this.Property(t => t.Title_loc4)
                .HasMaxLength(65535);

            this.Property(t => t.Title_loc5)
                .HasMaxLength(65535);

            this.Property(t => t.Title_loc6)
                .HasMaxLength(65535);

            this.Property(t => t.Title_loc7)
                .HasMaxLength(65535);

            this.Property(t => t.Title_loc8)
                .HasMaxLength(65535);

            this.Property(t => t.Details_loc1)
                .HasMaxLength(65535);

            this.Property(t => t.Details_loc2)
                .HasMaxLength(65535);

            this.Property(t => t.Details_loc3)
                .HasMaxLength(65535);

            this.Property(t => t.Details_loc4)
                .HasMaxLength(65535);

            this.Property(t => t.Details_loc5)
                .HasMaxLength(65535);

            this.Property(t => t.Details_loc6)
                .HasMaxLength(65535);

            this.Property(t => t.Details_loc7)
                .HasMaxLength(65535);

            this.Property(t => t.Details_loc8)
                .HasMaxLength(65535);

            this.Property(t => t.Objectives_loc1)
                .HasMaxLength(65535);

            this.Property(t => t.Objectives_loc2)
                .HasMaxLength(65535);

            this.Property(t => t.Objectives_loc3)
                .HasMaxLength(65535);

            this.Property(t => t.Objectives_loc4)
                .HasMaxLength(65535);

            this.Property(t => t.Objectives_loc5)
                .HasMaxLength(65535);

            this.Property(t => t.Objectives_loc6)
                .HasMaxLength(65535);

            this.Property(t => t.Objectives_loc7)
                .HasMaxLength(65535);

            this.Property(t => t.Objectives_loc8)
                .HasMaxLength(65535);

            this.Property(t => t.OfferRewardText_loc1)
                .HasMaxLength(65535);

            this.Property(t => t.OfferRewardText_loc2)
                .HasMaxLength(65535);

            this.Property(t => t.OfferRewardText_loc3)
                .HasMaxLength(65535);

            this.Property(t => t.OfferRewardText_loc4)
                .HasMaxLength(65535);

            this.Property(t => t.OfferRewardText_loc5)
                .HasMaxLength(65535);

            this.Property(t => t.OfferRewardText_loc6)
                .HasMaxLength(65535);

            this.Property(t => t.OfferRewardText_loc7)
                .HasMaxLength(65535);

            this.Property(t => t.OfferRewardText_loc8)
                .HasMaxLength(65535);

            this.Property(t => t.RequestItemsText_loc1)
                .HasMaxLength(65535);

            this.Property(t => t.RequestItemsText_loc2)
                .HasMaxLength(65535);

            this.Property(t => t.RequestItemsText_loc3)
                .HasMaxLength(65535);

            this.Property(t => t.RequestItemsText_loc4)
                .HasMaxLength(65535);

            this.Property(t => t.RequestItemsText_loc5)
                .HasMaxLength(65535);

            this.Property(t => t.RequestItemsText_loc6)
                .HasMaxLength(65535);

            this.Property(t => t.RequestItemsText_loc7)
                .HasMaxLength(65535);

            this.Property(t => t.RequestItemsText_loc8)
                .HasMaxLength(65535);

            this.Property(t => t.EndText_loc1)
                .HasMaxLength(65535);

            this.Property(t => t.EndText_loc2)
                .HasMaxLength(65535);

            this.Property(t => t.EndText_loc3)
                .HasMaxLength(65535);

            this.Property(t => t.EndText_loc4)
                .HasMaxLength(65535);

            this.Property(t => t.EndText_loc5)
                .HasMaxLength(65535);

            this.Property(t => t.EndText_loc6)
                .HasMaxLength(65535);

            this.Property(t => t.EndText_loc7)
                .HasMaxLength(65535);

            this.Property(t => t.EndText_loc8)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText1_loc1)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText1_loc2)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText1_loc3)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText1_loc4)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText1_loc5)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText1_loc6)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText1_loc7)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText1_loc8)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText2_loc1)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText2_loc2)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText2_loc3)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText2_loc4)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText2_loc5)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText2_loc6)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText2_loc7)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText2_loc8)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText3_loc1)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText3_loc2)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText3_loc3)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText3_loc4)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText3_loc5)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText3_loc6)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText3_loc7)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText3_loc8)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText4_loc1)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText4_loc2)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText4_loc3)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText4_loc4)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText4_loc5)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText4_loc6)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText4_loc7)
                .HasMaxLength(65535);

            this.Property(t => t.ObjectiveText4_loc8)
                .HasMaxLength(65535);

        }
    }
}
