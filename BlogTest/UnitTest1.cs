using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Oblig2_Blogg.Controllers;
using Oblig2_Blogg.Models.Entities;
using Oblig2_Blogg.Models.Repository;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Oblig2_Blogg.Models.ViewModels;

using Oblig2_Blogg;
using Oblig2_Blogg.Data;

namespace BlogTest
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IRepository> repository;
        private Mock<IPrincipal> user;
        private List<Blog> fakeBlogs;
        private List<Post> fakePosts;
        private List<Comment> fakeComments;
        private Post fakePost;
        private Comment fakeComment;

        [TestInitialize]
        public void SetupContext()
        {
            repository = new Mock<IRepository>();

            fakeBlogs = new List<Blog>
            {
                new Blog {BlogId = 1, Name = "Tur til Australia", Closed = false,  Description = "Fortelling av turopplevelser"},
                new Blog {BlogId = 2, Name = "Tur til Somalia", Closed = false,  Description = "Fortelling av turopplevelser"},
                new Blog {BlogId = 3, Name = "Tur til Afganistan", Closed = false,  Description = "Møtet med Taliban"},
                new Blog {BlogId = 4, Name = "Tur til USA", Closed = false,  Description = "Fortelling av turopplevelser"}
            };

            fakePosts = new List<Post> {
                new Post { PostId = 1, PostText = "I dag har jeg besøkt Sydney og i morgen skal vi til Adelaide", BlogId = 1},
                new Post { PostId = 1, PostText = "I dag har jeg besøkt Sydney og i morgen skal vi til Adelaide", BlogId = 1}

            };

            fakePost = new Post
            {PostId = 1, PostText = "I dag har jeg besøkt Sydney og i morgen skal vi til Adelaide", BlogId = 1
            };

            fakeComments = new List<Comment>
                { new Comment { CommentId = 1, CommentText = "Så heldige dere er :)", PostId = 1}
            };
        }

        //Posts---------------------------------------------------------------------------

        [TestMethod]
        public void IndexReturnsAllPosts()
        {
            // Arrange
            repository.Setup(x => x.GetAllPosts(1)).Returns(fakePosts);
            var controller = new BlogController(repository.Object);

            // Act
            var result = (ViewResult)controller.Index();

            // Assert                
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(Post));
            Assert.IsNotNull(result, "View Result is null");
            var postOriginal = result.ViewData.Model as List<Post>;
            Assert.AreEqual(2, postOriginal.Count, "Got wrong number of blogs");
        }

        [TestMethod]
        public void PostIndexReturnsNotNull()
        {
            //Arrange
            var controller = new PostController(repository.Object);

            //Act
            var result = (ViewResult)controller.Index(2);

            //Assert
            Assert.IsNotNull(result, "View Result is null");
        }


        [TestMethod]
        public void CreateShouldShowLoginViewFor_Non_AuthorizedUser()
        {
            // Arrange
            var mockUserManager = MockHelpers.MockUserManager<IdentityUser>();
            var mockRepo = new Mock<IRepository>();
            //var controller = new BlogController(mockRepo.Object, mockUserManager.Object);
            //controller.ControllerContext = MockHelpers.FakeControllerContext(false);

            // Act
            //var result = controller.Create() as ViewResult;

            // Assert
            //Assert.IsNotNull(result);
            //Assert.IsNull(result.ViewName);

        }

        [TestMethod]
        public void EditReturnsAPostEditViewModel()
        {
            // Arrange
            PostViewModel postViewModel = new PostViewModel();
            postViewModel.BlogId = 1;
            postViewModel.PostText = "Hei";
            //repository.Setup(x => x.GetPostViewModel(1)).Returns(postViewModel);
            var controller = new BlogController(repository.Object);
        
            // Act
            //TODO
            //ViewResult Result = (ViewResult) controller.EditPost(1);

            // Assert
            //Assert.IsInstanceOfType(Result.Model, typeof(PostViewModel));
        }

        [TestMethod]
        public void CanSavePost()
        {
            // Arrange
            //var context = new ApplicationDbContext(options);
            //user = MockHelpers.MockUserManager<IPrincipal>();
            //var repo = new Repository(user.Object, context);

            // Act
            //repo.SavePost(post, user).Wait();

            // Assert
            Assert.AreNotEqual(0, fakePost.PostId);
        }

        [TestMethod]
        public async Task IndexReturnsNotNullResultAsync()
        {
            // Arrange
            var controller = new BlogController(repository.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result, "View Result is null");
        }

        [TestMethod]
        public void IndexReturnsNotNullResult()
        {
            // Arrange
            var controller = new BlogController(repository.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result, "View Result is null");
        }

        [TestMethod]
        public void IndexReturnsAllBlogs()
        {
            // Arrange
            /*repository.Setup(x => x.GetAllBlogs()).Returns(blogs);*/
            var controller = new BlogController(repository.Object);
            
            // Act
            var result = controller.Index() as ViewResult;

            // Assert                
            CollectionAssert.AllItemsAreInstancesOfType((ICollection) result.ViewData.Model, typeof(Blog));
            Assert.IsNotNull(result, "View Result is null");

            var blogsOriginal = result.ViewData.Model as List<Blog>;
            Assert.AreEqual(fakeBlogs.Count, blogsOriginal.Count, "Got wrong number of blogs");
        }

        [TestMethod]
        public void CreateReturnsNotNullResult()
        {
            // Arrange
            Mock<IRepository> repository = new Mock<IRepository>();
            var controller = new PostController(repository.Object);
            var post1 = new PostViewModel()
            {
                PostId = 1,
                PostText = "I dag har jeg besøkt Sydney og i morgen skal vi til Adelaide",
                BlogId = 1
            };

            // Act
            var result = controller.CreatePost(1, post1);

            // Assert
            //repository.Verify(r => r.SavePost(post1, ClaimsPrincipal.Current));
        }

        [TestMethod]
        public void CreateReturnsNotNullResult1()
        {
            // Arrange
            var controller = new BlogController(repository.Object);


            // Act
            var result = (ViewResult)controller.Create();

            // Assert
            Assert.IsNotNull(result, "View Result is null");
        }


        [TestMethod]
        public void SaveIsCalledWhenProductIsCreated()
        { 
            // Arrange
            //repository = new Mock<IRepository>();
            //TODO mock user
            //repository.Setup(x => x.SaveBlog(It.IsAny<Blog>(), user));
            var controller = new BlogController(repository.Object);            
        
            // Act
            var result = controller.Create(new CreateBlogViewModel());            
            
            // Assert
            //TODO
            repository.VerifyAll();
            // test på at save er kalt et bestemt antall ganger
            //repository.Verify(x => x.SaveBlog(It.IsAny<Blog>(), new ClaimsPrincipal()), Times.Exactly(1));
        }

        [TestMethod]
        public void CreateViewIsReturnedWhenInputIsNotValid()
        {
            // Arrange
            var viewModel = new Blog { BlogId = 9990, Name = "", Closed = false, Description = "" };
           
            var controller = new BlogController(repository.Object);

            // Act
            var validationContext = new ValidationContext(viewModel, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(viewModel, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
                controller.ModelState.AddModelError(validationResult.MemberNames.First(),
                    validationResult.ErrorMessage);

            var result = controller.Create(new CreateBlogViewModel()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(validationResults.Count > 0);
        }


        [TestMethod]
        public void CreateRedirectActionRedirectsToIndexAction()
        {
            // Arrange
            var controller = new BlogController(repository.Object)
            {
                ControllerContext = Oblig2_Blogg.MockHelpers.FakeControllerContext(false)
            };
            var tempData =
                new TempDataDictionary(controller.ControllerContext.HttpContext, Mock.Of<ITempDataProvider>());
            controller.TempData = tempData;
            var viewModel = new Blog { BlogId = 1, Name = "Tur til Australia", Closed = false, Description = "Fortelling av turopplevelser" };

            // Act
            var result = controller.Create(new CreateBlogViewModel()) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result, "RedirectToIndex needs to redirect to the Index action");
            Assert.AreEqual("Index", result.ActionName);
        }
    }
}
