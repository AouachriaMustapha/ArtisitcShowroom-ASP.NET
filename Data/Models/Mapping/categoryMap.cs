using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class categoryMap : EntityTypeConfiguration<category>
    {
        public categoryMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("category");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.description).HasColumnName("description");

            // Relationships
            this.HasMany(t => t.artworks1)
                .WithMany(t => t.categories)
                .Map(m =>
                    {
                        m.ToTable("category_artwork");
                        m.MapLeftKey("Category_id");
                        m.MapRightKey("artworks_id");
                    });


        }
    }
}
