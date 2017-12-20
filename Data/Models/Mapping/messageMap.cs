using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class messageMap : EntityTypeConfiguration<message>
    {
        public messageMap()
        {
            // Primary Key
            this.HasKey(t => t.idMessage);

            // Properties
            this.Property(t => t.idMessage)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.text)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("message");
            this.Property(t => t.idMessage).HasColumnName("idMessage");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.text).HasColumnName("text");
            this.Property(t => t.idSender).HasColumnName("idSender");
            this.Property(t => t.idReceiver).HasColumnName("idReceiver");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.messages)
                .HasForeignKey(d => d.idSender);
            this.HasOptional(t => t.user1)
                .WithMany(t => t.messages1)
                .HasForeignKey(d => d.idReceiver);

        }
    }
}
