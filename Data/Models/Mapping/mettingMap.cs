using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class mettingMap : EntityTypeConfiguration<metting>
    {
        public mettingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.fk_artist, t.mettingDate, t.fk_owner, t.place });

            // Properties
            this.Property(t => t.fk_artist)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.fk_owner)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.place)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("metting");
            this.Property(t => t.fk_artist).HasColumnName("fk_artist");
            this.Property(t => t.mettingDate).HasColumnName("mettingDate");
            this.Property(t => t.fk_owner).HasColumnName("fk_owner");
            this.Property(t => t.place).HasColumnName("place");

            // Relationships
            this.HasRequired(t => t.user)
                .WithMany(t => t.mettings)
                .HasForeignKey(d => d.fk_artist).WillCascadeOnDelete(false) ;
            this.HasRequired(t => t.user1)
                .WithMany(t => t.mettings1)
                .HasForeignKey(d => d.fk_owner).WillCascadeOnDelete(false);

        }
    }
}
