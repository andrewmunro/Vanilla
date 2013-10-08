using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class locales_npc_textMap : EntityTypeConfiguration<locales_npc_text>
    {
        public locales_npc_textMap()
        {
            // Primary Key
            this.HasKey(t => t.entry);

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Text0_0_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text0_0_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text0_0_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text0_0_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text0_0_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text0_0_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text0_0_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text0_0_loc8)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text0_1_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text0_1_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text0_1_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text0_1_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text0_1_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text0_1_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text0_1_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text0_1_loc8)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text1_0_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text1_0_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text1_0_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text1_0_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text1_0_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text1_0_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text1_0_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text1_0_loc8)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text1_1_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text1_1_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text1_1_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text1_1_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text1_1_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text1_1_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text1_1_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text1_1_loc8)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text2_0_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text2_0_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text2_0_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text2_0_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text2_0_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text2_0_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text2_0_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text2_0_loc8)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text2_1_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text2_1_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text2_1_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text2_1_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text2_1_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text2_1_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text2_1_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text2_1_loc8)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text3_0_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text3_0_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text3_0_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text3_0_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text3_0_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text3_0_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text3_0_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text3_0_loc8)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text3_1_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text3_1_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text3_1_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text3_1_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text3_1_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text3_1_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text3_1_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text3_1_loc8)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text4_0_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text4_0_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text4_0_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text4_0_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text4_0_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text4_0_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text4_0_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text4_0_loc8)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text4_1_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text4_1_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text4_1_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text4_1_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text4_1_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text4_1_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text4_1_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text4_1_loc8)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text5_0_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text5_0_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text5_0_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text5_0_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text5_0_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text5_0_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text5_0_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text5_0_loc8)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text5_1_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text5_1_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text5_1_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text5_1_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text5_1_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text5_1_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text5_1_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text5_1_loc8)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text6_0_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text6_0_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text6_0_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text6_0_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text6_0_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text6_0_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text6_0_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text6_0_loc8)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text6_1_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text6_1_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text6_1_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text6_1_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text6_1_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text6_1_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text6_1_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text6_1_loc8)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text7_0_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text7_0_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text7_0_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text7_0_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text7_0_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text7_0_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text7_0_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text7_0_loc8)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text7_1_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text7_1_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text7_1_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text7_1_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text7_1_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text7_1_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text7_1_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text7_1_loc8)
                .HasMaxLength(1073741823);

        }
    }
}
