using Microsoft.EntityFrameworkCore;
using Oblig2_Blogg.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Oblig2_Blogg.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
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
            string dateString1 = "Sep 18, 2021";
            string dateString2 = "Sep 19, 2021";
            DateTime dateCreated = DateTime.Parse(dateString);
            DateTime dateCreated1 = DateTime.Parse(dateString1);
            DateTime dateCreated2 = DateTime.Parse(dateString2);

            //BLOG
            modelBuilder.Entity<Blog>()
               .HasData(
                new Blog { BlogId = 1, Name = "Tur til Australia", Closed = false, Created = dateCreated, Description = "Fortelling av turopplevelser" });
            modelBuilder.Entity<Blog>()
               .HasData(
                new Blog { BlogId = 2, Name = "Tur til Afganistan", Closed = false, Created = dateCreated, Description = "Møtet med Taliban" });
            modelBuilder.Entity<Blog>()
               .HasData(
                new Blog { BlogId = 3, Name = "Tur til Thailand", Closed = false, Created = dateCreated, Description = "Barna likte båttur" });

            //POST
            modelBuilder.Entity<Post>()
                .HasData(
                    new Post { PostId = 1, PostText = "I dag har jeg besøkt Sydney og i morgen skal vi til Adelaide", Created = dateCreated, BlogId = 1});
            modelBuilder.Entity<Post>()
                .HasData(
                    new Post { PostId = 2, PostText = "Melbourne på vei til Adelaide var et kjempefint sted", Created = dateCreated, BlogId = 1 });
            modelBuilder.Entity<Post>()
                .HasData(
                    new Post { PostId = 3, PostText = "Skulle startet fjellturen via Kunduz. Men møtet med Taliban var ikke så hyggelig", Created = dateCreated2, BlogId = 2 });
            modelBuilder.Entity<Post>()
                .HasData(
                    new Post { PostId = 4, PostText = "Barna ble litt lei hotellet i Phuket. Da tok vi oss en båttur til Ko Khao Khat", Created = dateCreated1, BlogId = 3 });

            //COMMENT
            modelBuilder.Entity<Comment>()
                .HasData(
                    new Comment { CommentId = 1, CommentText = "Så heldige dere er :)", Created = dateCreated, PostId = 1 });
            modelBuilder.Entity<Comment>()
                .HasData(
                    new Comment { CommentId = 2, CommentText = "Dere må innom den store parken i byen", Created = dateCreated, PostId = 1 });
            modelBuilder.Entity<Comment>()
                .HasData(
                    new Comment { CommentId = 3, CommentText = "Hvem er Taliban??", Created = dateCreated, PostId = 3 });
            modelBuilder.Entity<Comment>()
                .HasData(
                    new Comment { CommentId = 4, CommentText = "Husk å ikke gi mat til apene..)", Created = dateCreated, PostId = 4 });
        }
    }
}
