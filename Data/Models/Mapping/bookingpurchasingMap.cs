using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class bookingpurchasingMap : EntityTypeConfiguration<bookingpurchasing>
    {
        public bookingpurchasingMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("bookingpurchasing");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.advencePayement).HasColumnName("advencePayement");
            this.Property(t => t.bookingDate).HasColumnName("bookingDate");
            this.Property(t => t.purchasingDate).HasColumnName("purchasingDate");
            this.Property(t => t.fk_client).HasColumnName("fk_client");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.bookingpurchasings)
                .HasForeignKey(d => d.fk_client);

        }
    }
}
