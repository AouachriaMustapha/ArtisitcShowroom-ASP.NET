using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class ratingartistMap : EntityTypeConfiguration<ratingartist>
    {
        public ratingartistMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id_artist, t.id_client });

            // Properties
            this.Property(t => t.id_artist)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_client)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ratingartist");
            this.Property(t => t.id_artist).HasColumnName("id_artist");
            this.Property(t => t.id_client).HasColumnName("id_client");
            this.Property(t => t.mark).HasColumnName("mark");
            this.Property(t => t.result).HasColumnName("result");

            // Relationships
            this.HasRequired(t => t.user)
                .WithMany(t => t.ratingartists)
                .HasForeignKey(d => d.id_client);
            this.HasRequired(t => t.user1)
                .WithMany(t => t.ratingartists1)
                .HasForeignKey(d => d.id_artist).WillCascadeOnDelete(false);

        }
    }
}
