using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class spaceMap : EntityTypeConfiguration<space>
    {
        public spaceMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.adress)
                .HasMaxLength(255);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("space");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.adress).HasColumnName("adress");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.disponibility).HasColumnName("disponibility");
            this.Property(t => t.file).HasColumnName("file");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.rentalPrice).HasColumnName("rentalPrice");
            this.Property(t => t.owner_id).HasColumnName("owner_id");

            // Relationships
            this.HasMany(t => t.users)
                .WithMany(t => t.spaces1)
                .Map(m =>
                    {
                        m.ToTable("user_space");
                        m.MapLeftKey("spaces_id");
                        m.MapRightKey("User_id");
                    });

            this.HasOptional(t => t.user)
                .WithMany(t => t.spaces)
                .HasForeignKey(d => d.owner_id);

        }
    }
}
