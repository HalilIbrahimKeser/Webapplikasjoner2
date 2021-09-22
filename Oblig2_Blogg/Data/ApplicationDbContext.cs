using Microsoft.EntityFrameworkCore;
using Oblig2_Blogg.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig2_Blogg.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Blog>().ToTable("Blog");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Comment>().ToTable("Comment");

            // Seeding
            string dateString = "Sep 17, 2021";
            DateTime dateCreated = DateTime.Parse(dateString);

            modelBuilder.Entity<Blog>()
               .HasData(
                new Blog { Name = "Tur til Australia", Closed = false, Created = dateCreated, Description = "Fortelling av turopplevelser" });
            modelBuilder.Entity<Blog>()
               .HasData(
                new Blog { Name = "Tur til Afganistan", Closed = false, Created = dateCreated, Description = "Møtet med Taliban" });
            modelBuilder.Entity<Blog>()
               .HasData(
                new Blog { Name = "Tur til Thailand", Closed = false, Created = dateCreated, Description = "Barna likte båttu" });
        }
    }
}
