using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class SeminarDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Follow> Follows { get; set; }

        public SeminarDBContext(DbContextOptions options) : base(options)
        {
        }

        // https://docs.microsoft.com/en-us/ef/core/modeling/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setup the delete method for all of the entities using reflection
            /*foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                 relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }*/

            /* one-to-many relationship */

            modelBuilder.Entity<Post>()
                .HasOne(post => post.Creator)
                .WithMany(user => user.Posts)
                .HasForeignKey(post => post.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(comment => comment.Post)
                .WithMany(post => post.Comments)
                .HasForeignKey(comment => comment.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(comment => comment.Commenter)
                .WithMany(user => user.Comments)
                .HasForeignKey(comment => comment.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // working M2N

            modelBuilder.Entity<User>()
                .HasMany(x => x.Followers)
                .WithOne(x => x.Followee)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Follows)
                .WithOne(x => x.Follower)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Follow>()
                .HasOne(x => x.Follower)
                .WithMany(x => x.Follows);

            modelBuilder.Entity<Follow>()
                .HasOne(x => x.Followee)
                .WithMany(x => x.Followers);

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}
