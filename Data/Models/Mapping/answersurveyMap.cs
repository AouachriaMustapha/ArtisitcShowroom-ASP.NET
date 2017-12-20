using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class answersurveyMap : EntityTypeConfiguration<answersurvey>
    {
        public answersurveyMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.answer)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("answersurvey");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.answer).HasColumnName("answer");
            this.Property(t => t.fk_questionsuervey).HasColumnName("fk_questionsuervey");

            // Relationships
            this.HasOptional(t => t.questionsurvey)
                .WithMany(t => t.answersurveys)
                .HasForeignKey(d => d.fk_questionsuervey);

        }
    }
}
