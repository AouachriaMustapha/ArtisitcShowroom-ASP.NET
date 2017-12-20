using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class questionsurveyMap : EntityTypeConfiguration<questionsurvey>
    {
        public questionsurveyMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.question)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("questionsurvey");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.answer).HasColumnName("answer");
            this.Property(t => t.question).HasColumnName("question");
            this.Property(t => t.fk_survey).HasColumnName("fk_survey");

            // Relationships
            this.HasOptional(t => t.survey)
                .WithMany(t => t.questionsurveys)
                .HasForeignKey(d => d.fk_survey);

        }
    }
}
