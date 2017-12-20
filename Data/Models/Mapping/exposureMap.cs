using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class exposureMap : EntityTypeConfiguration<exposure>
    {
        public exposureMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.endDate)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            this.Property(t => t.startDate)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("exposure");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.endDate).HasColumnName("endDate");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.startDate).HasColumnName("startDate");
            this.Property(t => t.fk_space).HasColumnName("fk_space");
            this.Property(t => t.fk_survey).HasColumnName("fk_survey");
            this.Property(t => t.EDate).HasColumnName("eDate");
            this.Property(t => t.SDate).HasColumnName("sDate");

            // Relationships
            this.HasMany(t => t.artworks1)
                .WithMany(t => t.exposures)
                .Map(m =>
                    {
                        m.ToTable("exposure_artwork");
                        m.MapLeftKey("Exposure_id");
                        m.MapRightKey("artworks_id");
                    });

            this.HasOptional(t => t.survey)
                .WithMany(t => t.exposures)
                .HasForeignKey(d => d.fk_survey);
            this.HasOptional(t => t.space)
                .WithMany(t => t.exposures)
                .HasForeignKey(d => d.fk_space);

        }
    }
}
