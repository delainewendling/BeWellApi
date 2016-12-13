using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BeWellApi.Models;

namespace BeWellApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivityProgress> ActivityProgress { get; set; }
        public DbSet<Emotion> Emotion { get; set; }
        public DbSet<EmotionActivity> EmotionActivity { get; set; }
        public DbSet<EmotionCategory> EmotionCategory { get; set; }
        public DbSet<UserEmotion> UserEmotion { get; set; }
        public DbSet<SavedActivity> SavedActivity { get; set; }
        public DbSet<UserAssessment> UserAssessment { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ActivityProgress>()
               .Property(b => b.DateCompleted)
               .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<UserEmotion>()
              .Property(b => b.DateLogged)
              .HasDefaultValueSql("CURRENT_TIMESTAMP");

        }
    }
}
