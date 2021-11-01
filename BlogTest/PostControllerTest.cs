using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Oblig2_Blogg;
using Oblig2_Blogg.Authorization;
using Oblig2_Blogg.Controllers;
using Oblig2_Blogg.Models.Entities;
using Oblig2_Blogg.Models.Repository;
using Oblig2_Blogg.Models.ViewModels;

namespace BlogTest
{
    [TestClass]
    public class PostControllerTest
    {
        private Mock<IRepository> _repository;
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private List<Blog> _fakeBlogs;
        private Blog _fakeBlog;
        private List<Post> _fakePosts;
        private List<Tag> _fakeTags;
        private List<Comment> _fakeComments;
        private IndexViewModel _fakeIndexViewModel;
        private BlogViewModel _fakeBlogViewModel;
        private PostViewModel _fakePostViewModel;
        private IAuthorizationService _authService;
        private ClaimsPrincipal _user;
        private ApplicationUser _appUser;
        private BlogApplicationUser _blogApplicationUser;
        private BlogController _blogController;
        private PostController _postController;
        private CommentController _commentController;

        private IAuthorizationService BuildAuthorizationService(Action<IServiceCollection> setupServices = null)
        {
            //https://codingblast.com/asp-net-core-unit-testing-authorizationservice-inside-controller/*
            var services = new ServiceCollection();
            services.AddAuthorization();
            services.AddLogging();
            services.AddOptions();
            setupServices?.Invoke(services);
            return services.BuildServiceProvider().GetRequiredService<IAuthorizationService>();
        }

        [TestInitialize]
        public void SetupContext()
        {
            _repository = new Mock<IRepository>();
            _mockUserManager = Oblig2_Blogg.MockHelpers.MockUserManager<ApplicationUser>();
            _mockUserManager.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("1234");
            var authHandler = new EntityAuthorizationHandler(_mockUserManager.Object);

            _authService = BuildAuthorizationService(services =>
            {
                services.AddScoped(_ => _repository?.Object);
                services.AddScoped<IAuthorizationHandler>(_ => authHandler);

                services.AddAuthorization(options =>
                {
                    options.AddPolicy("Basic", policy =>
                    {
                        policy.AddAuthenticationSchemes("Basic");
                        policy.RequireClaim("Permission", "CanViewPage");
                    });
                });
            });

            _postController = new PostController(_repository.Object, _authService);
            _blogController = new BlogController(_repository.Object, _mockUserManager.Object, _authService);
            _commentController = new CommentController(_repository.Object, _authService);

            _fakeBlogs = new List<Blog>
            {
                new() {BlogId = 1, Name = "Australia", Closed = false},
                new() {BlogId = 2, Name = "Thailand", Closed = false},
                new() {BlogId = 3, Name = "Forente Stater", Closed = false}
            };

            _fakeBlog = new Blog
            {
                BlogId = 1,
                Name = "Australia",
                Closed = false,
                Owner = new ApplicationUser("ibrahim@keser.no")
            };


            _fakePosts = new List<Post>
            {
                new() {PostId = 1, BlogId = 1, PostText = "Fint tur"},
                new() {PostId = 2, BlogId = 1, PostText = "God tur"},
                new() {PostId = 3, BlogId = 1, PostText = "Faen du reiser mye"}
            };
            _fakeComments = new List<Comment>
            {
                new() {CommentId = 1, PostId = 1, CommentText = "Så fint"},
                new() {CommentId = 2, PostId = 1, CommentText = "Så flott"},
                new() {CommentId = 3, PostId = 1, CommentText = "Supert!"},
            };

            _fakeTags = new List<Tag>
            {
                new() {TagId = 1, TagLabel = "Natur"},
                new() {TagId = 1, TagLabel = "Skog"},
                new() {TagId = 1, TagLabel = "Skitur"},
            };

            _fakeIndexViewModel = new IndexViewModel()
            {
                Blogs = _fakeBlogs,
                Posts = _fakePosts,
                Tags = _fakeTags,
                Comments = _fakeComments
            };

            _fakeBlogViewModel = new BlogViewModel()
            {
                BlogId = 2,
                Name = "Blognavn",
                Description = "Opplevelser",
                Posts = _fakePosts
            };


            _fakePostViewModel = new PostViewModel()
            {
                PostId = 1,
                PostText = "Postteksten",
                BlogId = 1,
                Tags = _fakeTags,
                Comments = _fakeComments
            };

            _appUser = new ApplicationUser()
            {
                UserName = "Halldalf",
                Password = "Postteksten",
            };

            _blogApplicationUser = new BlogApplicationUser()
            {
                Owner = _appUser,
                Blog = _fakeBlog,
                BlogId = _fakeBlog.BlogId
            };
        }

        [TestMethod]
        public async Task PostIndexReturnsNotNullResult()
        {
            // Arrange
            _postController = new PostController(_repository.Object, _authService);

            // Act
            var result = (ViewResult)_postController.Index(1);

            // Assert
            Assert.IsNotNull(result, "View Result is null");
        }

        //[TestMethod]
        //public void SaveIsCalledWhenPostIsCreated()
        //{
        //    // Arrange
        //    _postController.ControllerContext = MockHelpers.FakeControllerContext(true);
        //    _repository.Setup(x => x.SavePost(It.IsAny<Post>(), It.IsAny<ClaimsPrincipal>()));
        //    _repository.Setup(x => x.GetBlog(1)).Returns(_fakeBlog);
        //    _mockUserManager.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>()))
        //        .Returns(Task.FromResult(new ApplicationUser { Id = "53f02aab-27d8-4173-a1d6-e4a0c2a3a77f" }));


        //    // Act
        //    var result = _postController.CreatePost(1);
            
        //    // Assert
        //    _repository.VerifyAll();
        //    Assert.IsNotNull(result, "Result is null");
        //    _repository.Verify(x => x.SavePost(It.IsAny<Post>(), It.IsAny<ClaimsPrincipal>()), Times.Exactly(1));
        //}







    }
}
