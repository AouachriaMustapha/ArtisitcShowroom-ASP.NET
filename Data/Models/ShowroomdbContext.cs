using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Data.Models.Mapping;
using Domain.Entity;

namespace Data.Models


{
    
    public partial class ShowroomdbContext : DbContext
    {
        static ShowroomdbContext()
        {
            Database.SetInitializer<ShowroomdbContext>(null);
        }

        public ShowroomdbContext()
            : base("Name=showroomdb")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<answersurvey> answersurveys { get; set; }
        public DbSet<artwork> artworks { get; set; }
        public DbSet<bookingpurchasing> bookingpurchasings { get; set; }
        public DbSet<category> categories { get; set; }
        public DbSet<claims> claims { get; set; }
        public DbSet<details> details { get; set; }
        public DbSet<exposure> exposures { get; set; }
        public DbSet<message> messages { get; set; }
        public DbSet<metting> mettings { get; set; }
        public DbSet<questionsurvey> questionsurveys { get; set; }
        public DbSet<ratingartist> ratingartists { get; set; }
        public DbSet<space> spaces { get; set; }
        public DbSet<specialty> specialties { get; set; }
        public DbSet<subscription> subscriptions { get; set; }
        public DbSet<survey> surveys { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<rentspace> rentspaces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new answersurveyMap());
            modelBuilder.Configurations.Add(new artworkMap());
            modelBuilder.Configurations.Add(new bookingpurchasingMap());
            modelBuilder.Configurations.Add(new categoryMap());
            modelBuilder.Configurations.Add(new claimMap());
            modelBuilder.Configurations.Add(new detailMap());
            modelBuilder.Configurations.Add(new exposureMap());
            modelBuilder.Configurations.Add(new messageMap());
            modelBuilder.Configurations.Add(new mettingMap());
            modelBuilder.Configurations.Add(new questionsurveyMap());
            modelBuilder.Configurations.Add(new ratingartistMap());
            modelBuilder.Configurations.Add(new spaceMap());
            modelBuilder.Configurations.Add(new specialtyMap());
            modelBuilder.Configurations.Add(new subscriptionMap());
            modelBuilder.Configurations.Add(new surveyMap());
            modelBuilder.Configurations.Add(new userMap());
            modelBuilder.Configurations.Add(new rentspaceMap());
            modelBuilder.Entity<ExpositionArtwork>()
           .HasKey(x => new { x.artworkId, x.exposureId });
        }
    }
}
