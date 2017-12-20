using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class subscriptionMap : EntityTypeConfiguration<subscription>
    {
        public subscriptionMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.datedebut)
                .HasMaxLength(255);

            this.Property(t => t.datefin)
                .HasMaxLength(255);

            this.Property(t => t.etat)
                .HasMaxLength(255);

            this.Property(t => t.type)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("subscription");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.datedebut).HasColumnName("datedebut");
            this.Property(t => t.datefin).HasColumnName("datefin");
            this.Property(t => t.etat).HasColumnName("etat");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.artist_id).HasColumnName("artist_id");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.subscriptions)
                .HasForeignKey(d => d.artist_id);

        }
    }
}
