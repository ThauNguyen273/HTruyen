using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HTruyenDB;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
              .HasOne(u => u.UserWallet)
              .WithOne()
              .HasForeignKey<User>(u => u.UserWalletId);

            modelBuilder.Entity<User>()
              .HasOne(u => u.UserPlan)
              .WithMany()
              .HasForeignKey(u => u.UserPlanId);

            modelBuilder.Entity<User>()
              .HasOne(u => u.Role)
              .WithMany()
              .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Novel>()
              .HasOne(n => n.Category)
              .WithMany()
              .HasForeignKey(n => n.CategoryId);

            modelBuilder.Entity<Comment>()
              .HasOne(c => c.User)
              .WithMany()
              .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Comment>()
              .HasOne(c => c.Novel)
              .WithMany()
              .HasForeignKey(c => c.NovelId);

            modelBuilder.Entity<Chapter>()
              .HasOne(ch => ch.Novel)
              .WithMany()
              .HasForeignKey(ch => ch.NovelId);

            modelBuilder.Entity<Ratings>()
              .HasOne(r => r.User)
              .WithMany()
              .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Ratings>()
              .HasOne(r => r.Novel)
              .WithMany()
              .HasForeignKey(r => r.NovelId);

            modelBuilder.Entity<ForumThread>()
              .HasOne(t => t.User)
              .WithMany()
              .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<ForumThread>()
              .HasOne(t => t.Forum)
              .WithMany()
              .HasForeignKey(t => t.ForumId);

            modelBuilder.Entity<ForumPost>()
              .HasOne(p => p.User)
              .WithMany()
              .HasForeignKey(p => p.UserId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ForumPost>()
              .HasOne(p => p.Thread)
              .WithMany()
              .HasForeignKey(p => p.ThreadId);

            modelBuilder.Entity<ForumLike>()
              .HasOne(l => l.User)
              .WithMany()
              .HasForeignKey(l => l.UserId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ForumLike>()
              .HasOne(l => l.Post)
              .WithMany()
              .HasForeignKey(l => l.PostId);

            modelBuilder.Entity<UserSubscription>()
              .HasOne(s => s.User)
              .WithMany()
              .HasForeignKey(s => s.UserId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserSubscription>()
              .HasOne(s => s.Plan)
              .WithMany()
              .HasForeignKey(s => s.PlanId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFeedback>()
             .HasOne(f => f.User)
             .WithMany()
             .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<UserFavorite>()
              .HasOne(f => f.User)
              .WithMany()
              .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<UserFavorite>()
              .HasOne(f => f.Novel)
              .WithMany()
              .HasForeignKey(f => f.NovelId);

            modelBuilder.Entity<Transaction>()
                .HasOne(tr => tr.User)
                .WithMany()
                .HasForeignKey(tr => tr.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserStorie>()
                .HasOne(us => us.User)
                .WithMany()
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StoryChapter>()
                .HasOne(sc => sc.Story)
                .WithMany()
                .HasForeignKey(sc => sc.StoryId);

        }

        public DbSet<User> User { get; set; }
        public DbSet<UserPlan> UserPlan { get; set; }
        public DbSet<UserWallet> UserWallet { get; set; }
        public DbSet<UserSubscription> UserSubscription { get; set; }
        public DbSet<UserFavorite> UserFavorite { get; set; }
        public DbSet<UserFeedback> UserFeedback { get; set; }
        public DbSet<UserStorie> UserStorie { get; set; }
        public DbSet<StoryChapter> StoryChapter { get; set; }
        public DbSet<Category> Categorie { get; set; }
        public DbSet<Novel> Novel  { get; set; }
        public DbSet<Chapter> Chapter  { get; set; }
        public DbSet<Comment> Comment  { get; set; }
        public DbSet<Ratings> Rating { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Forum> Forum{ get; set; }
        public DbSet<ForumThread> ForumThread { get; set; }
        public DbSet<ForumPost> ForumPost { get; set; }
        public DbSet<ForumLike> ForumLike { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}
