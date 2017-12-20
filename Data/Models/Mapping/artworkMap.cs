using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class artworkMap : EntityTypeConfiguration<artwork>
    {
        public artworkMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("artwork");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.photo).HasColumnName("photo");
            this.Property(t => t.phot).HasColumnName("phot");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.artist_id).HasColumnName("artist_id");
            this.Property(t => t.bookingPurchasing_id).HasColumnName("bookingPurchasing_id");
            this.Property(t => t.category_id).HasColumnName("category_id");
            this.Property(t => t.fk_exposure).HasColumnName("fk_exposure");

            // Relationships
            this.HasMany(t => t.users)
                .WithMany(t => t.artworks1)
                .Map(m =>
                    {
                        m.ToTable("user_artwork");
                        m.MapLeftKey("artworks_id");
                        m.MapRightKey("User_id");
                    });

            this.HasOptional(t => t.user)
                .WithMany(t => t.artworks)
               .HasForeignKey(d => d.artist_id);
            this.HasOptional(t => t.bookingpurchasing)
                .WithMany(t => t.artworks)
                .HasForeignKey(d => d.bookingPurchasing_id);
            this.HasOptional(t => t.category)
                .WithMany(t => t.artworks)
                .HasForeignKey(d => d.category_id);
            this.HasOptional(t => t.exposure)
                .WithMany(t => t.artworks)
                .HasForeignKey(d => d.fk_exposure);

        }
    }
}
