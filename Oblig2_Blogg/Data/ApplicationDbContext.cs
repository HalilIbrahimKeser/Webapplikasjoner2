using Microsoft.EntityFrameworkCore;
using Oblig2_Blogg.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Oblig2_Blogg.Authorization;
using Oblig2_Blogg.Models.ViewModels;

namespace Oblig2_Blogg.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //https://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx

            modelBuilder.Entity<BlogViewModel>().HasNoKey();

            modelBuilder.Entity<ApplicationUser>().HasMany<Blog>();
            modelBuilder.Entity<Blog>().HasMany<ApplicationUser>();


            // Seeding

            //BLOG
            modelBuilder.Entity<Blog>()
               .HasData(
                new Blog { BlogId = 1, Name = "Tur til Australia", Closed = false, Created = DateTime.Now, Description = "Fortelling av turopplevelser" });
            modelBuilder.Entity<Blog>()
               .HasData(
                new Blog { BlogId = 2, Name = "Tur til Afganistan", Closed = false, Created = DateTime.Now, Description = "Møtet med Taliban" });
            modelBuilder.Entity<Blog>()
               .HasData(
                new Blog { BlogId = 3, Name = "Tur til Thailand", Closed = false, Created = DateTime.Now, Description = "Barna likte båttur" });

            //POST
            modelBuilder.Entity<Post>()
                .HasData(
                    new Post { PostId = 1, PostText = "I dag har jeg besøkt Sydney og i morgen skal vi til Adelaide", Created = DateTime.Now, BlogId = 1 });
            modelBuilder.Entity<Post>()
                .HasData(
                    new Post { PostId = 2, PostText = "Melbourne på vei til Adelaide var et kjempefint sted", Created = DateTime.Now, BlogId = 1 });
            modelBuilder.Entity<Post>()
                .HasData(
                    new Post { PostId = 3, PostText = "Skulle startet fjellturen via Kunduz. Men møtet med Taliban var ikke så hyggelig", Created = DateTime.Now, BlogId = 2 });
            modelBuilder.Entity<Post>()
                .HasData(
                    new Post { PostId = 4, PostText = "Barna ble litt lei hotellet i Phuket. Da tok vi oss en båttur til Ko Khao Khat", Created = DateTime.Now, BlogId = 3 });

            //COMMENT
            modelBuilder.Entity<Comment>()
                .HasData(
                    new Comment { CommentId = 1, CommentText = "Så heldige dere er :)", Created = DateTime.Now, PostId = 1 });
            modelBuilder.Entity<Comment>()
                .HasData(
                    new Comment { CommentId = 2, CommentText = "Dere må innom den store parken i byen", Created = DateTime.Now, PostId = 1 });
            modelBuilder.Entity<Comment>()
                .HasData(
                    new Comment { CommentId = 3, CommentText = "Hvem er Taliban??", Created = DateTime.Now, PostId = 3 });
            modelBuilder.Entity<Comment>()
                .HasData(
                    new Comment { CommentId = 4, CommentText = "Husk å ikke gi mat til apene..)", Created = DateTime.Now, PostId = 4 });


            //modelBuilder.Entity<ApplicationUser>()
            //    .HasData(
            //        new ApplicationUser { FirstName = "Seher", LastName = "Keser", UserName = "seher@keser.no", PasswordHash = "seher1234"});


            ////TAG
            //modelBuilder.Entity<Tag>()
            //    .HasData(
            //        new Tag { TagId = 1, TagLabel = "Natur", Created = DateTime.Now});
            //modelBuilder.Entity<Tag>()
            //    .HasData(
            //        new Tag { TagId = 2, TagLabel = "Fjell", Created = DateTime.Now });
            //modelBuilder.Entity<Tag>()
            //    .HasData(
            //        new Tag { TagId = 3, TagLabel = "Ørken", Created = DateTime.Now});
            //modelBuilder.Entity<Tag>()
            //    .HasData(
            //        new Tag { TagId = 4, TagLabel = "Farlig", Created = DateTime.Now});
            //modelBuilder.Entity<Tag>()
            //    .HasData(
            //        new Tag { TagId = 5, TagLabel = "Løping", Created = DateTime.Now});
            //modelBuilder.Entity<Tag>()
            //    .HasData(
            //        new Tag { TagId = 6, TagLabel = "Sykling", Created = DateTime.Now});
            //modelBuilder.Entity<Tag>()
            //    .HasData(
            //        new Tag { TagId = 7, TagLabel = "Gåtur", Created = DateTime.Now});

            //    ////TAG
            //    modelBuilder.Entity<PostTag>()
            //        .HasData(
            //            new PostsAndTags { TagId = 1, PostId = 1 });
            //    modelBuilder.Entity<PostsAndTags>()
            //        .HasData(
            //            new PostsAndTags { TagId = 2, PostId = 1 });
            //    modelBuilder.Entity<PostsAndTags>()
            //        .HasData(
            //            new PostsAndTags { TagId = 3, PostId = 2 });
            //    modelBuilder.Entity<PostsAndTags>()
            //        .HasData(
            //            new PostsAndTags { TagId = 4, PostId = 2 });
            //    modelBuilder.Entity<PostsAndTags>()
            //        .HasData(
            //            new PostsAndTags { TagId = 5, PostId = 3 });
            //    modelBuilder.Entity<PostsAndTags>()
            //        .HasData(
            //            new PostsAndTags { TagId = 6, PostId = 3 });
            //    modelBuilder.Entity<PostsAndTags>()
            //        .HasData(
            //            new PostsAndTags { TagId = 7, PostId = 1 });
        }

        public DbSet<BlogViewModel> BlogViewModel { get; set; }
    }
}
