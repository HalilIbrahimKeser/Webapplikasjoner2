using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Moq;
using Oblig2_Blogg;
using Oblig2_Blogg.Data;
using Oblig2_Blogg.Models.Entities;
using Oblig2_Blogg.Models.Repository;
using Xunit;
using Assert = Xunit.Assert;

namespace BlogTest
{
    public abstract class RepositoryTest
    {
        #region Seeding
        protected DbContextOptions<ApplicationDbContext> ContextOptions { get; }

        protected RepositoryTest(DbContextOptions<ApplicationDbContext> contextOptions)
        {
            ContextOptions = contextOptions;
            Seed();
        }

        private void Seed()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                {
                    context.Blogs.AddRange(
                        new Blog { Name = "Thailand", Closed = false, Created = DateTime.Now },
                        new Blog { Name = "Somalia", Closed = false, Created = DateTime.Now },
                        new Blog { Name = "Tanzania", Closed = false, Created = DateTime.Now }
                    );

                    Post post3;
                    Post post4;

                    context.Posts.AddRange(
                        post3 = new Post
                        {
                            BlogId = 1,
                            PostText = "Posttext nummer 1",
                            Created = DateTime.Now,
                        },

                        post4 = new Post
                        {
                            BlogId = 2,
                            PostText = "Posttext nummer 2",
                            Created = DateTime.Now,
                        }
                    );


                    context.Comments.AddRange(

                        new Comment { PostId = 1, CommentText = "Jalla tar oss en tur" },
                        new Comment { PostId = 1, CommentText = "Flott dette her" },
                        new Comment { PostId = 2, CommentText = "God tur" }
                    );

                    context.Tags.AddRange(
                        new Tag { TagLabel = "Natur", Posts = new List<Post> { post3 } },
                        new Tag { TagLabel = "Fjell", Posts = new List<Post> { post4, post3 } },
                        new Tag { TagLabel = "Strand", Posts = new List<Post> { post4 } }
                    );

                    context.SaveChanges();
                }

            }
        }
        #endregion

        [Fact]
        public async Task CanGetAllBlogs()
        {
            await using var context = new ApplicationDbContext(ContextOptions);
            
            //Arrange
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);

            //Act
            var result = repository.GetAllBlogs();
            
            //Assert
            Assert.Equal(6, result.Count()); 
            var blogs = result.ToList();
            
            Assert.Equal("Tur til Australia", blogs[0].Name);
            Assert.Equal("Tur til Afganistan", blogs[1].Name);
            Assert.Equal("Tur til Thailand", blogs[2].Name);
        }

        [Fact]
        public void CanGetBlog()
        {
            using var context = new ApplicationDbContext(ContextOptions);
            
            //Arrange
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);
            
            //Act
            var item = repository.GetBlog(2);
            
            //Assert
            Assert.Equal("Tur til Afganistan", item.Name);
        }

        [Fact]
        public void CanGetPostViewModel()
        {
            using var context = new ApplicationDbContext(ContextOptions);
            
            //Arrange
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);
            
            //Act
            var item = repository.GetPostViewModel(4);
            
            //Assert
            Assert.Equal(4, item.PostId);
        }

        [Fact]
        public void CanGetAllPostsOnBlog()
        {
            using var context = new ApplicationDbContext(ContextOptions);
            
            //Arrange
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);
            
            //Act
            var result = repository.GetAllPostsInBlog(2);
            
            //Assert
            Assert.Equal(2, result.Count());
            var testList = result.ToList();
            Assert.Equal("Posttext nummer 2", testList[0].PostText);
            Assert.Equal("Skulle startet fjellturen via Kunduz. Men møtet med Taliban var ikke så hyggelig", testList[1].PostText);

        }

        [Fact]
        public void CanGetPost()
        {
            using var context = new ApplicationDbContext(ContextOptions);
            
            //Arrange
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);
           
            //Act
            var item = repository.GetPost(2);
            
            //Assert
            Assert.Equal("Melbourne på vei til Adelaide var et kjempefint sted", item.PostText);
        }

        [Fact]
        public async Task CanGetAllComments()
        {
            await using var context = new ApplicationDbContext(ContextOptions);
            
            //Arrange
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);
            
            //Act
            var result = repository.GetAllComments().ToList();
            
            //Assert
            Assert.Equal(7, result.Count());
            
            var comments = result.ToList();
            Assert.Equal("Husk å ikke gi mat til apene..)", comments[0].CommentText);
            Assert.Equal("Hvem er Taliban??", comments[1].CommentText);
            Assert.Equal("Dere må innom den store parken i byen", comments[2].CommentText);
            Assert.Equal("Så heldige dere er :)", comments[3].CommentText);
            Assert.Equal("Jalla tar oss en tur", comments[4].CommentText);
            Assert.Equal("Flott dette her", comments[5].CommentText);
        }


        [Fact]
        public async Task GetAllCommentsOnPost()
        {
            await using var context = new ApplicationDbContext(ContextOptions);
            
            //Arrange
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);
            
            //Act
            var result = await repository.GetAllCommentsOnPost(2);
            
            //Assert
            Assert.Equal(1, result.Count());

            var comments = result.ToList();
            Assert.Equal("God tur", comments[0].CommentText);

        }

        [Fact]
        public void CanGetComment()
        {
            using var context = new ApplicationDbContext(ContextOptions);
            
            //Arrange
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);
            
            //Act
            var item = repository.GetComment(1);
            
            //Assert
            Assert.Equal("Så heldige dere er :)", item.CommentText);

        }


        [Fact]
        public async Task CanGetAllTags()
        {
            await using var context = new ApplicationDbContext(ContextOptions);
            
            //Arrange
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);
            
            //Act
            var result =  repository.GetAllTags().ToList();
            
            //Assert
            Assert.Equal(3, result.Count());
            var comments = result as List<Tag>;
            Assert.Equal("Natur", comments[0].TagLabel);
            Assert.Equal("Fjell", comments[1].TagLabel);
            Assert.Equal("Strand", comments[2].TagLabel);

        }

        [Fact]
        public void CanGetAllTagsForBlog()
        {
            using var context = new ApplicationDbContext(ContextOptions);
            
            //Arrange
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);
            
            //Act
            var result = repository.GetAllTagsForBlog(2).ToList(); 
            
            //Assert
            Assert.Equal(2, result.Count());
            
            var tags = result.ToList();
            Assert.Equal("Fjell", tags[0].TagLabel);
            Assert.Equal("Strand", tags[1].TagLabel);
        }


        [Fact]
        public void CanGetTag()
        {
            using var context = new ApplicationDbContext(ContextOptions);
           
            //Arrange
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);
            
            //Act
            var item = repository.GetTag(1);
            
            //Assert
            Assert.Equal("Natur", item.TagLabel);

        }

        [Fact]
        public void CanSaveBlog()
        {
            using ApplicationDbContext context = new(ContextOptions);
            
            //Arrange
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);
            var blog = new Blog { Name = "Nytt Blogg", Created = DateTime.Now, Closed = true };

            //Act
            //https://stackoverflow.com/questions/38323895/how-to-add-claims-in-a-mock-claimsprincipal
            repository.SaveBlog(blog, new TestPrincipal(
                new Claim("name", "John Doe", "id", "53f02aab-27d8-4173-a1d6-e4a0c2a3a77f"))).Wait();
            
            //Assert
            Assert.NotEqual(0, blog.BlogId);
        }

        [Fact]
        public void CanSavePost()
        {
            using ApplicationDbContext context = new(ContextOptions);
            
            //Arrange
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);
            var post = new Post { PostText = "Nytt", Created = DateTime.Now, BlogId = 2, };
            mockUserManager.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>()))
                .Returns(Task.FromResult(new ApplicationUser { Id = "53f02aab-27d8-4173-a1d6-e4a0c2a3a77f" }));

            //Act
            //https://stackoverflow.com/questions/38323895/how-to-add-claims-in-a-mock-claimsprincipal
            repository.SavePost(post, new TestPrincipal(
                new Claim("name",  "John Doe","id", "53f02aab-27d8-4173-a1d6-e4a0c2a3a77f"))).Wait();
            
            //Assert
            Assert.NotEqual(0, post.BlogId);
        }

        [Fact]
        public async Task CanSaveCommentWithOwner()
        {
            await using ApplicationDbContext context = new(ContextOptions);
            
            //Arrange
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);
            var comment = new Comment { CommentText = "Nytt kommentar", PostId = 2, };

            //Act
            //https://stackoverflow.com/questions/38323895/how-to-add-claims-in-a-mock-claimsprincipal
            repository.SaveComment(comment, new TestPrincipal(
                new Claim("name", "John Doe", "id", "53f02aab-27d8-4173-a1d6-e4a0c2a3a77f"))).Wait();
            //Assert
            Assert.NotEqual(0, comment.CommentId);
        }

        [Fact]
        public async Task CanSaveOnlyCommentAndReturnStatusCodeOk()
        {
            //Arrange
            var owner = new ApplicationUser()
            {
                Id = "12345"
            };

            var post = new Post
            {
                BlogId = 1,
                PostText = "Posttext",
                Created = DateTime.Now,
            };
            await using ApplicationDbContext context = new(ContextOptions);
            //Arrange
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);
            var comment = new Comment { CommentText = "Kommentar", PostId = 2, Owner = owner, Post = post };

            //Act
            //https://stackoverflow.com/questions/38323895/how-to-add-claims-in-a-mock-claimsprincipal
            var status = await Task.FromResult(repository.SaveComment(comment)).Result;
            
            //Assert
            Assert.NotEqual(0, comment.CommentId);
            Assert.True(status);
        }

        [Fact]
        public void CanDeletePost()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);
            var post = new Post { BlogId = 1 };
            
            //Act
            _ = repository.DeletePost(post, new TestPrincipal(new Claim("name", "John Doe")));
            
            //Assert
            Assert.False(context.Set<Post>().Any(e => e.PostText == "Post"));
        }

        [Fact]
        public void CanDeleteComment()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions); 
            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
            var repository = new Repository(context, mockUserManager.Object);
            var comment = new Comment { PostId = 1 };
            
            //Act
            _ = repository.DeleteComment(comment, new TestPrincipal(new Claim("name", "John Doe")));
            
            //Assert
            Assert.False(context.Set<Comment>().Any(e => e.CommentText == "Kommentar"));
        }
        

        //https://stackoverflow.com/questions/38323895/how-to-add-claims-in-a-mock-claimsprincipal
        public class TestPrincipal : ClaimsPrincipal
        {
            public TestPrincipal(params Claim[] claims) : base(new TestIdentity(claims))
            {
            }
        }

        public class TestIdentity : ClaimsIdentity
        {
            public TestIdentity(params Claim[] claims) : base(claims)
            {
            }
        }
    }
}
