//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Oblig2_Blogg;
//using Oblig2_Blogg.Data;
//using Oblig2_Blogg.Models.Entities;
//using Oblig2_Blogg.Models.Repository;

//namespace BlogTest
//{
//    class RepositoryTest
//    {
//        #region Seeding
//        protected DbContextOptions<ApplicationDbContext> ContextOptions { get; }

//        protected RepositoryTest(DbContextOptions<ApplicationDbContext> contextOptions)
//        {
//            ContextOptions = contextOptions;
//            Seed();
//        }

//        private void Seed()
//        {
//            using (var context = new ApplicationDbContext(ContextOptions))
//            {
//                context.Database.EnsureDeleted();
//                context.Database.EnsureCreated();
//                { 
//                    context.Blogs.AddRange(
//                        new Blog { Name = "Thailand", Closed = false, Created = DateTime.Now },
//                        new Blog { Name = "Somalia", Closed = false, Created = DateTime.Now },
//                        new Blog { Name = "Tanzania", Closed = false, Created = DateTime.Now }
//                    );

//                    Post post3;
//                    Post post4;

//                    context.Posts.AddRange(
//                        post3 = new Post
//                        {
//                            BlogId = 1,
//                            PostText = "Posttext nummer 1",
//                            Created = DateTime.Now,
//                        },

//                        post4 = new Post
//                        {
//                            BlogId = 2,
//                            PostText = "Posttext nummer 2",
//                            Created = DateTime.Now,
//                        }
//                    );


//                    context.Comments.AddRange(

//                        new Comment { PostId = 1, CommentText = "Jalla tar oss en tur" },
//                        new Comment { PostId = 1, CommentText = "Flott dette her" },
//                        new Comment { PostId = 2, CommentText = "God tur" }
//                    );

//                    context.Tags.AddRange(
//                        new Tag { TagLabel = "Natur", Posts = new List<Post> { post3 } },
//                        new Tag { TagLabel = "Fjell", Posts = new List<Post> { post4, post3 } },
//                        new Tag { TagLabel = "Strand", Posts = new List<Post> { post4 } }
//                    );

//                    context.SaveChanges();
//                }

//            }
//        }

//        #endregion

//        [Fact]
//        public async Task CanGetAllBlogs()
//        {
//            await using var context = new ApplicationDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new Repository(context, mockUserManager.Object, authorizationService1);

//            //Act
//            var result = await repository.GetAllBlogs();
//            //Assert
//            Assert.Equal(7, result.Count()); //4 in db, 3 in in-memory db
//            var blogs = result as List<Blogg>;
//            Assert.Equal("Lorem ipsum dolor", blogs[0].Name);
//            Assert.Equal("Quisque convallis est", blogs[1].Name);
//            Assert.Equal("Interdum et malesuada", blogs[2].Name);
//        }

//        [Fact]
//        public void CanGetBlog()
//        {
//            using var context = new BlogDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            //Act
//            var item = repository.GetBlog(2);
//            //Assert
//            Assert.Equal("Quisque convallis est", item.Name);
//        }

//        [Fact]
//        public void CanGetCreateBlogViewModel()
//        {
//            using var context = new BlogDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            //Act
//            var item = repository.GetCreateBlogViewModel(2);
//            //Assert
//            Assert.Equal("Quisque convallis est", item.Name);
//        }

//        [Fact]
//        public void CanGetPostViewModel()
//        {
//            using var context = new BlogDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            //Act
//            var item = repository.GetPostViewModel(4);
//            //Assert
//            Assert.Equal("Nysgerring på antallet", item.Content);
//        }

//        [Fact]
//        public void CanGetAllPostsOnBlog()
//        {
//            using var context = new BlogDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            //Act
//            var result = repository.GetAllPosts(2);
//            //Assert
//            Assert.Equal(2, result.Count()); //1 in db, 1 in in-memory db
//            var testList = result.ToList();
//            Assert.Equal("Ingen over ingen under", testList[0].Title);
//            Assert.Equal("Second post", testList[1].Title);

//        }

//        [Fact]
//        public void CanGetPost()
//        {
//            using var context = new BlogDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            //Act
//            var item = repository.GetPost(2);
//            //Assert
//            Assert.Equal("Second post", item.Title);
//        }

//        [Fact]
//        public async Task CanGetAllComments()
//        {
//            await using var context = new BlogDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            //Act
//            var result = await repository.GetAllComments();
//            //Assert
//            Assert.Equal(6, result.Count()); //4 in db, 3 in in-memory db
//            var comments = result as List<Comment>;
//            Assert.Equal("Is this latin?", comments[0].Text);
//            Assert.Equal("Yes, of course it is", comments[1].Text);
//            Assert.Equal("I really like the blog, but Quisque?", comments[2].Text);
//            Assert.Equal("På tide å skifte dekk", comments[3].Text);
//            Assert.Equal("En diplomatisk avslutning", comments[4].Text);
//            Assert.Equal("Det var for grunt til å dykke", comments[5].Text);
//        }

//        [Fact]
//        public async Task GetAllCommentsOnPost()
//        {
//            await using var context = new BlogDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            //Act
//            var result = await repository.GetAllCommentsOnPost(2);
//            //Assert
//            Assert.Equal(2, result.Count()); //1 in db, 1 in in-memory db
//            var comments = result as List<Comment>;
//            Assert.Equal("I really like the blog, but Quisque?", comments[0].Text);
//            Assert.Equal("Det var for grunt til å dykke", comments[1].Text);

//        }

//        [Fact]
//        public void CanGetComment()
//        {
//            using var context = new BlogDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            //Act
//            var item = repository.GetComment(1);
//            //Assert
//            Assert.Equal("Is this latin?", item.Text);

//        }


//        [Fact]
//        public async Task CanGetAllTags()
//        {
//            await using var context = new BlogDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            //Act
//            var result = await repository.GetAllTags();
//            //Assert
//            Assert.Equal(3, result.Count());
//            var comments = result as List<Tag>;
//            Assert.Equal("#dekk", comments[0].TagLabel);
//            Assert.Equal("#diplomati", comments[1].TagLabel);
//            Assert.Equal("#dykking", comments[2].TagLabel);

//        }

//        [Fact]
//        public void CanGetAllTagsForBlog()
//        {
//            using var context = new BlogDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            //Act
//            var result = repository.GetAllTagsForBlog(2); //Get all tags for posts on a blog
//            //Assert
//            Assert.Equal(2, result.Count());
//            var tags = result.ToList();
//            Assert.Equal("#diplomati", tags[0].TagLabel);
//            Assert.Equal("#dykking", tags[1].TagLabel);
//        }

//        [Fact]
//        public void CanGetAllPostsInThisBlogWithThisTag()
//        {
//            using var context = new BlogDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            var result = repository.GetAllPostsInThisBlogWithThisTag(3, 1); //Get all posts in this blog with a specific tag
//            //Assert
//            var posts = result.ToList();
//            Assert.Single(result);
//            Assert.Equal("Bare en tittel", posts[0].Title);
//        }

//        [Fact]
//        public void CanGetTag()
//        {
//            using var context = new BlogDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            //Act
//            var item = repository.GetTag(1);
//            //Assert
//            Assert.Equal("#dekk", item.TagLabel);

//        }

//        [Fact]
//        public void CanSaveBlog()
//        {

//            using BlogDbContext context = new(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            var blog = new Blogg { Name = "Another old favorite", Created = DateTime.Now, ClosedForPosts = true };

//            //Act
//            //https://stackoverflow.com/questions/38323895/how-to-add-claims-in-a-mock-claimsprincipal
//            repository.SaveBlog(blog, new TestPrincipal(new Claim("name", "John Doe"))).Wait();
//            //Assert
//            Assert.NotEqual(0, blog.BlogId);
//        }

//        [Fact]
//        public void CanSavePost()
//        {
//            using BlogDbContext context = new(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            var post = new Post { Title = "Posting!!!", Created = DateTime.Now, Content = "Slettes ikke værst", BlogId = 2, };

//            //Act
//            //https://stackoverflow.com/questions/38323895/how-to-add-claims-in-a-mock-claimsprincipal
//            repository.SavePost(post, new TestPrincipal(new Claim("name", "John Doe"))).Wait();
//            //Assert
//            Assert.NotEqual(0, post.BlogId);
//        }

//        [Fact]
//        public async Task CanSaveCommentWithOwner()
//        {
//            await using BlogDbContext context = new(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            var comment = new Comment { Text = "Posting!!!", Created = DateTime.Now, PostId = 2, };

//            //Act
//            //https://stackoverflow.com/questions/38323895/how-to-add-claims-in-a-mock-claimsprincipal
//            repository.SaveComment(comment, new TestPrincipal(new Claim("name", "John Doe"))).Wait();
//            //Assert
//            Assert.NotEqual(0, comment.CommentId);
//        }

//        [Fact]
//        public async Task CanSaveOnlyCommentAndReturnStatusCodeOk()
//        {
//            //Arrange
//            var owner = new ApplicationUser()
//            {
//                Id = "12345"
//            };

//            var post = new Post
//            {
//                BlogId = 1,
//                Title = "Bare en tittel",
//                Created = DateTime.Now,
//                Content = "Bananer i lange baner"
//            };
//            await using BlogDbContext context = new(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            var comment = new Comment { Text = "Posting Posting!!!", Created = DateTime.Now, Modified = DateTime.Now, PostId = 2, Owner = owner, Post = post };

//            //Act
//            //https://stackoverflow.com/questions/38323895/how-to-add-claims-in-a-mock-claimsprincipal
//            //repository.SaveComment(comment).Wait();
//            var returnsOkStatus = await Task.FromResult(repository.SaveComment(comment)).Result;
//            //Assert
//            Assert.NotEqual(0, comment.CommentId);
//            Assert.True(returnsOkStatus);
//        }

//        [Fact]
//        public void CanDeletePost()
//        {
//            using var context = new BlogDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            var post = new Post { BlogId = 1 };
//            //Act
//            _ = repository.DeletePost(post);
//            //Assert
//            Assert.False(context.Set<Post>().Any(e => e.Content == "Hammer"));
//        }

//        [Fact]
//        public void CanDeleteComment()
//        {
//            using var context = new BlogDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            var comment = new Comment { PostId = 1 };
//            //Act
//            _ = repository.DeleteComment(comment);
//            //Assert
//            Assert.False(context.Set<Comment>().Any(e => e.Text == "Hammer"));
//        }

//        [Fact]
//        public void CanSetBlogStatus()
//        {
//            using var context = new BlogDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);
//            Blogg blog = repository.GetBlog(1);
//            //Act
//            repository.SetBlogStatus(blog, true);
//            //Assert
//            Assert.True(blog.ClosedForPosts);
//        }

//        [Fact]
//        public void CheckIfBlogIsActive()
//        {
//            using var context = new BlogDbContext(ContextOptions);
//            //Arrange
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);

//            //Act
//            Blogg blog = repository.GetBlog(1);
//            //Assert
//            Assert.False(repository.IsActive(blog));
//        }


//        [Fact]
//        public void CheckIfCommentExists()
//        {
//            //Arrange
//            using var context = new BlogDbContext(ContextOptions);
//            var mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
//            var repository = new BlogRepository(mockUserManager.Object, context);

//            //Assert
//            Assert.True(repository.CommentExists(1));
//            Assert.False(repository.CommentExists(100));
//        }

//        /*public async Task IndexReturnsAllBlogsAndIsOfCorrectType()
//        {
//            Mock<IBlogRepository> _repository = new Mock<IBlogRepository>();
//            // Arrange
//            _repository.Setup(x => x.GetAllBlogs()).Returns(Task.FromResult(_fakeBloggs.AsEnumerable()));
//            // Act
//            var result =  await _blogController.Index() as ViewResult;
//            // Assert
//            Assert.IsNotNull(result, "View Result is null");
//            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(Blogg));
//            //
//            var blogs = result.ViewData.Model as List<Blogg>;
//            Assert.AreNotEqual(_fakeBloggs.Count, blogs.Count, "Forskjellig antall blogger");
//        }
//        */

//        //https://stackoverflow.com/questions/38323895/how-to-add-claims-in-a-mock-claimsprincipal
//        public class TestPrincipal : ClaimsPrincipal
//        {
//            public TestPrincipal(params Claim[] claims) : base(new TestIdentity(claims))
//            {
//            }
//        }

//        public class TestIdentity : ClaimsIdentity
//        {
//            public TestIdentity(params Claim[] claims) : base(claims)
//            {
//            }
//        }
//    }
//}
