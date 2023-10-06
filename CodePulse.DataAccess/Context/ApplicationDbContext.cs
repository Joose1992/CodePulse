using CodePulse.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePulse.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<BlogPostsModel> BlogPosts { get; set; }
        public DbSet<CategoriesModel> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=lenovo_Jose;Database=CodePulseDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPostsModel>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Id);

                    entity.Property(e => e.Title);

                    entity.Property(e => e.Author);

                    entity.Property(e => e.ShortDescription);

                    entity.Property(e => e.Content);

                    entity.Property(e => e.FeatureImageUrl);

                    entity.Property(e => e.UrlHandle);

                    entity.Property(e => e.PublishedDate);

                    entity.Property(e => e.IsVisible);
                }
                );
            modelBuilder.Entity<CategoriesModel>(
                entity =>
                {
                    entity.HasKey(e =>e.Id);
                    entity.Property(e => e.Id);

                    entity.Property(e => e.Name);

                    entity.Property(e => e.UrlHandle);
                }
                );
        }
    }
}
