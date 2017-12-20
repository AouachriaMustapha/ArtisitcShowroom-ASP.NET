using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class userMap : EntityTypeConfiguration<user>
    {
        public userMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.type)
                .IsRequired()
                .HasMaxLength(31);

            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.city)
                .HasMaxLength(255);

            this.Property(t => t.fileUrl)
                .HasMaxLength(255);

            this.Property(t => t.firstName)
                .HasMaxLength(255);

            this.Property(t => t.lastName)
                .HasMaxLength(255);

            this.Property(t => t.login)
                .HasMaxLength(255);

            this.Property(t => t.mail)
                .HasMaxLength(255);

            this.Property(t => t.password)
                .HasMaxLength(255);

            this.Property(t => t.pictureUrl)
                .HasMaxLength(255);

            this.Property(t => t.postalCode)
                .HasMaxLength(255);

            this.Property(t => t.street)
                .HasMaxLength(255);

            this.Property(t => t.description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("user");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.age).HasColumnName("age");
            this.Property(t => t.city).HasColumnName("city");
            this.Property(t => t.confirm).HasColumnName("confirm");
            this.Property(t => t.fileUrl).HasColumnName("fileUrl");
            this.Property(t => t.firstName).HasColumnName("firstName");
            this.Property(t => t.lastName).HasColumnName("lastName");
            this.Property(t => t.login).HasColumnName("login");
            this.Property(t => t.mail).HasColumnName("mail");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.phone).HasColumnName("phone");
            this.Property(t => t.photo).HasColumnName("photo");
            this.Property(t => t.pictureUrl).HasColumnName("pictureUrl");
            this.Property(t => t.postalCode).HasColumnName("postalCode");
            this.Property(t => t.street).HasColumnName("street");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.experience).HasColumnName("experience");

            // Relationships
            this.HasMany(t => t.bookingpurchasings1)
                .WithMany(t => t.users)
                .Map(m =>
                    {
                        m.ToTable("user_bookingpurchasing");
                        m.MapLeftKey("User_id");
                        m.MapRightKey("bookingpurchasing_id");
                    });

            this.HasMany(t => t.specialties)
                .WithMany(t => t.users)
                .Map(m =>
                    {
                        m.ToTable("user_specialty");
                        m.MapLeftKey("artists_id");
                        m.MapRightKey("specialtys_id");
                    });


        }
    }
}
