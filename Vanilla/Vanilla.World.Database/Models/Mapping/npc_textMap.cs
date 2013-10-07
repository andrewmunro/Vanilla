using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class npc_textMap : EntityTypeConfiguration<npc_text>
    {
        public npc_textMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.text0_0)
                .HasMaxLength(1073741823);

            this.Property(t => t.text0_1)
                .HasMaxLength(1073741823);

            this.Property(t => t.text1_0)
                .HasMaxLength(1073741823);

            this.Property(t => t.text1_1)
                .HasMaxLength(1073741823);

            this.Property(t => t.text2_0)
                .HasMaxLength(1073741823);

            this.Property(t => t.text2_1)
                .HasMaxLength(1073741823);

            this.Property(t => t.text3_0)
                .HasMaxLength(1073741823);

            this.Property(t => t.text3_1)
                .HasMaxLength(1073741823);

            this.Property(t => t.text4_0)
                .HasMaxLength(1073741823);

            this.Property(t => t.text4_1)
                .HasMaxLength(1073741823);

            this.Property(t => t.text5_0)
                .HasMaxLength(1073741823);

            this.Property(t => t.text5_1)
                .HasMaxLength(1073741823);

            this.Property(t => t.text6_0)
                .HasMaxLength(1073741823);

            this.Property(t => t.text6_1)
                .HasMaxLength(1073741823);

            this.Property(t => t.text7_0)
                .HasMaxLength(1073741823);

            this.Property(t => t.text7_1)
                .HasMaxLength(1073741823);

        }
    }
}
