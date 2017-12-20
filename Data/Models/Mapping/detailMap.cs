using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class detailMap : EntityTypeConfiguration<details>
    {
        public detailMap()
        {
            // Primary Key
            this.HasKey(t => new { t.fk_artwork, t.detailDate, t.fk_space });

            // Properties
            this.Property(t => t.fk_artwork)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.fk_space)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("details");
            this.Property(t => t.fk_artwork).HasColumnName("fk_artwork");
            this.Property(t => t.detailDate).HasColumnName("detailDate");
            this.Property(t => t.fk_space).HasColumnName("fk_space");
            this.Property(t => t.exposure_id).HasColumnName("exposure_id");

            // Relationships
            this.HasMany(t => t.claims)
                .WithMany(t => t.details)
                .Map(m =>
                    {
                        m.ToTable("claims_details");
                        m.MapLeftKey("details_fk_artwork", "details_detailDate", "details_fk_space");
                        m.MapRightKey("Claims_id");
                    });

            this.HasRequired(t => t.artwork)
                .WithMany(t => t.details)
                .HasForeignKey(d => d.fk_artwork);
            this.HasRequired(t => t.space)
                .WithMany(t => t.details)
                .HasForeignKey(d => d.fk_space);
            this.HasOptional(t => t.exposure)
                .WithMany(t => t.details)
                .HasForeignKey(d => d.exposure_id);

        }
    }
}
