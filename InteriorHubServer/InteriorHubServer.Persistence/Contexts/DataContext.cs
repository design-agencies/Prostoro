using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using InteriorHubServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InteriorHubServer.Persistence.Contexts
{
    public class DataContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        protected readonly IConfiguration _configuration;

        public DbSet<City>? Cities { get; set; }
        public DbSet<Project>? Projects { get; set; }
        public DbSet<Agency>? Agencies { get; set; }
        public DbSet<Image>? Images { get; set; }
        public DbSet<ProjectImage>? ProjectImages { get; set; }
        public DbSet<ProjectElement>? ProjectElements { get; set; }
        public DbSet<Tag>? Tags { get; set; }
        public DbSet<Review>? Reviews { get; set; }
        public DbSet<Complaint>? Complaint { get; set; }
        public DbSet<Save>? Saves { get; set; }
        public DbSet<Like>? Likes { get; set; }
        public DbSet<Dialog>? Dialogs { get; set; }
        public DbSet<Message>? Messages { get; set; }
        public DbSet<NotificationSettings>? NotificationSettings { get; set; }
        public DbSet<ErrorInfo>? ErrorInfos { get; set; }

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(_configuration.GetConnectionString("Default"));
            //options.UseSqlServer(_configuration.GetConnectionString("Deployed"));
            //options.UseSqlServer(_configuration.GetConnectionString("Default")).LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Complaint>()
               .HasOne(c => c.Review)
               .WithMany(r => r.Complaints)
               .HasForeignKey(c => c.ReviewId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
               .HasOne(m => m.Dialog)
               .WithMany(d => d.Messages)
               .HasForeignKey(m => m.DialogId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
               .HasOne(m => m.Sender)
               .WithMany(u => u.Messages)
               .HasForeignKey(m => m.SenderId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Dialog>()
               .HasMany(d => d.Users)
               .WithMany(u => u.Dialogs);

            modelBuilder.Entity<Agency>()
                .HasMany(a => a.Followers)
                .WithMany(u => u.Follows);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Agency)
                .WithOne(a => a.User)
                .HasForeignKey<Agency>(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectElement>()
                .HasOne(pe => pe.ProjectImage)
                .WithOne(pi => pi.ProjectElement)
                .HasForeignKey<ProjectElement>(pe => pe.ProjectImageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
