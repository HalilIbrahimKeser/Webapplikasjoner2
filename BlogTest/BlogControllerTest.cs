using Oblig2_Blogg.Authorization;
using Oblig2_Blogg.Controllers;
using Oblig2_Blogg.Models;
using Oblig2_Blogg.Models.Entities;
using Oblig2_Blogg.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Oblig2_Blogg;
using Oblig2_Blogg.Models.Repository;

namespace BlogUnitTest
{

    [TestClass]
    public class BlogControllerTest
    {
        private Mock<IRepository> _repository;
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private List<Blog> _fakeBlogs;
        private List<Post> _fakePosts;
        private List<Tag> _fakeTags;
        private List<Comment> _fakeComments;
        private IndexViewModel _fakeIndexViewModel;
        private IAuthorizationService _authService;
        private ClaimsPrincipal _user;
        private PostController _postController;
        private BlogController _blogController;
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
            _mockUserManager = MockHelpers.MockUserManager<ApplicationUser>();
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
            _blogController = new BlogController(_repository.Object, _authService);
            _commentController = new CommentController(_repository.Object, _authService);

            _fakeBlogs = new List<Blog>{
                new() {BlogId = 1, Name = "Australia", Closed = false},
                new() {BlogId = 2, Name = "Thailand", Closed = false},
                new() {BlogId = 3, Name = "Forente Stater", Closed = false}
            };

            _fakePosts = new List<Post>{
                new() {PostId = 1, BlogId = 1, PostText = "Fint tur"},
                new() {PostId = 2, BlogId = 1, PostText = "God tur"},
                new() {PostId = 3, BlogId = 1, PostText = "Faen du reiser mye"}
            };
            _fakeComments = new List<Comment>{
                new() {CommentId = 1, PostId = 1, CommentText = "Så fint"},
                new() {CommentId = 2, PostId = 1, CommentText = "Så flott"},
                new() {CommentId = 3, PostId = 1, CommentText = "Supert!"},
            };

            _fakeTags = new List<Tag>{
                new() {TagId = 1, TagLabel = "Natur"},
                new() {TagId = 1, TagLabel = "Skog"},
                new() {TagId = 1, TagLabel = "Skitur"},
            };

            _fakeIndexViewModel = new IndexViewModel(){
                Blogs = _fakeBlogs,
                Posts = _fakePosts,
                Tags = _fakeTags,
                Comments = _fakeComments
            };
        }

        [TestMethod]
        public async Task BlogIndexReturnsNotNullResult()
        {
            // Arrange
            _blogController= new BlogController(_repository.Object, _authService);

            // Act
            var result = (ViewResult) _blogController.Index();

            // Assert
            Assert.IsNotNull(result, "View Result is null");
        }

        [TestMethod]
        public void SaveIsCalledWhenBlogIsCreated()
        {
            // Arrange
            _blogController.ControllerContext = MockHelpers.FakeControllerContext(true);
            _repository.Setup(x => x.SaveBlog(It.IsAny<Blog>(), It.IsAny<ClaimsPrincipal>()));

            // Act
            var result = _blogController.Create(new CreateBlogViewModel());
            // Assert
            _repository.VerifyAll();
            Assert.IsNotNull(result, "Result is null");
            _repository.Verify(x => x.SaveBlog(It.IsAny<Blog>(), It.IsAny<ClaimsPrincipal>()), Times.Exactly(1));
        }

        [TestMethod]
        public void CreateViewIsReturnedWhenInputIsNotValid()
        {
            // Arrange
            var viewModel = new CreateBlogViewModel()
            {
                Name = ""
            };

            // Act
            var validationContext = new ValidationContext(viewModel, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(viewModel, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                Debug.Assert(validationResult.ErrorMessage != null, "validationResult.ErrorMessage != null");
                _blogController.ModelState.AddModelError(validationResult.MemberNames.First(),
                    validationResult.ErrorMessage);
            }

            var result = _blogController.Create(viewModel) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(validationResults.Count > 0);
        }

        [TestMethod]
        public void CreateRedirectActionRedirectsToIndexActionAndController()
        {
            // Arrange
            _blogController.ControllerContext = MockHelpers.FakeControllerContext(false);

            var tempData = new TempDataDictionary(_blogController.ControllerContext.HttpContext, Mock.Of<ITempDataProvider>());
            _blogController.TempData = tempData;
           
            var viewModel = new CreateBlogViewModel()
            {
                Name = "Tur til Somalia",
                Closed = false
            };

            // Act
            var result = _blogController.Create(viewModel) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result, "RedirectToIndex needs to redirect to the Index action");
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Blog", result.ControllerName);
        }

        [TestMethod]
        public void CreateReturnsNotNullResult()
        {
            // Act
            var result = (ViewResult)_blogController.Create();

            // Assert
            Assert.IsNotNull(result, "View Result is null");
        }

        [TestMethod]
        public void CreateShouldShowLoginViewForNonAuthorizedUser()
        {
            // Arrange
            //Ikke logget inn
            _blogController.ControllerContext = MockHelpers.FakeControllerContext(false); 

            // Act
            var result = _blogController.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);
        }

        //[TestMethod]
        //public void DeltePost_RedirectsToNotAllowed()
        //{

        //    //Arrange
        //    var owner = new ApplicationUser()
        //    {
        //        Id = "12345"
        //    };
        //    var fakePost = new Post
        //    {
        //        BlogId = 3,
        //        PostId = 6,
        //        PostText = "Dette er en posttekst",
        //        Owner = owner,
        //        Blog = new Blog()
        //        {
        //            Name = "Navnet på bloggen",
        //            Closed = false
        //        }
        //    };

        //    _repository.Setup(x => x.GetPost(fakePost.PostId)).Returns(fakePost);
        //    //var user = new ApplicationUser("testuser");
        //    //user.Id = "1";
        //    _postController.ControllerContext = MockHelpers.FakeControllerContext(/*true, user.Id, user.UserName*/);
        //    var tempData = new TempDataDictionary(
        //        _postController.ControllerContext.HttpContext,
        //        Mock.Of<ITempDataProvider>()
        //    );

        //    _postController.TempData = tempData;

        //    var result = _postController.DeletePost(fakePost.PostId).Result as RedirectToActionResult;
        //    Assert.IsNotNull(result, "Should not be null");
        //    Assert.AreEqual("NotAllowed", result.ActionName);
        //}

        [TestMethod]
        public async Task IndexReturnsIndexViewModelOfCorrectType()
        {
            // Arrange
            _repository.Setup(x => x.GetAllBlogs()).Returns(_fakeIndexViewModel.Blogs.AsEnumerable());
            
            // Act
            var result = _blogController.Index() as ViewResult;
            
            // Assert
            Assert.IsNotNull(result, "View Result is null");
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(IndexViewModel));
            
            var IndexViewModel = result.ViewData.Model as List<IndexViewModel>;
            Assert.AreNotEqual(_fakeBlogs.Count, IndexViewModel.Count, "Forskjellig antall blogger");
        }


    }
}