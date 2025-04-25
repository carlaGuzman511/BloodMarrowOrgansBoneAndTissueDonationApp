using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Entities;

namespace Umss.BloodOrgansDonationApp.Repository
{
    public class DonationAppContext : DbContext
    {
        public DonationAppContext(DbContextOptions<DonationAppContext> options) : base(options) { }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DonationType> DonationTypes { get; set; }
        public DbSet<DonationCenter> DonationCenters { get; set; }
        public DbSet<DonationPost> DonationPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonationPost>()
            .HasOne(p => p.User)
            .WithMany(u => u.DonationPosts)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

            modelBuilder.Entity<DonationPost>()
            .HasOne(p => p.DonationCenter)
            .WithMany(dc => dc.DonationPosts)
            .HasForeignKey(p => p.DonationCenterId)
            .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

            modelBuilder.Entity<Comment>()
            .HasOne(p => p.DonationPost)
            .WithMany(c => c.Comments)
            .HasForeignKey(p => p.DonationPostId)
            .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction
        }

    }
}
