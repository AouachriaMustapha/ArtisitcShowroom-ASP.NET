using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Mapping
{
  public  class rentspaceMap : EntityTypeConfiguration<rentspace>
    {
        public rentspaceMap()
        {
            this.HasKey(t => new { t.fk_artist,  t.fk_space });

            this.Property(t => t.fk_artist)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.fk_space)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);



            this.ToTable("rentspace");
            this.Property(t => t.fk_artist).HasColumnName("fk_artist");
            this.Property(t => t.rentDate).HasColumnName("rentDate");
            this.Property(t => t.fk_space).HasColumnName("fk_space");

            this.HasRequired(t => t.user)
               .WithMany(t => t.rentspaces)
               .HasForeignKey(d => d.fk_artist).WillCascadeOnDelete(false);
            this.HasRequired(t => t.space)
                .WithMany(t => t.rentspaces)
                .HasForeignKey(d => d.fk_space).WillCascadeOnDelete(false);



        }


    }
}
