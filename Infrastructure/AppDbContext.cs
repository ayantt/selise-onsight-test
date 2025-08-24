using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Domain.Entity.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.FullName).IsRequired().HasMaxLength(200);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(200);
                entity.Property(u => u.Role).IsRequired().HasMaxLength(100);
            });

            // Team entity
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Name).IsRequired().HasMaxLength(200);
                entity.Property(t => t.Description).HasMaxLength(500);
            });

            // Task entity
            modelBuilder.Entity<Domain.Entity.Task>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Title).IsRequired().HasMaxLength(200);
                entity.Property(t => t.Description).HasMaxLength(500);
                entity.Property(t => t.Status).HasMaxLength(100);

                // Relationships
                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(t => t.AssignedToUserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(t => t.CreatedByUserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Team>()
                      .WithMany()
                      .HasForeignKey(t => t.TeamId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
