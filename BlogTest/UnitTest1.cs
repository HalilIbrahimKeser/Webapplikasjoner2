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
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BlogTest
{
    [TestClass]
    public class UnitTest1
    {
        //TODO skal det være Repository eller IRepository?
        private Mock<Repository> repository;
        private Mock<IPrincipal> user;

        private List<Blog> blogs;
        private List<Post> posts;
        private List<Comment> comments;

        [TestInitialize]
        public void SetupContext()
        {
            repository = new Mock<Repository>();
            blogs = new List<Blog>
            {
                new Blog {Name = "Tur til Australia", Closed = false,  Description = "Fortelling av turopplevelser"},
                new Blog {Name = "Tur til Somalia", Closed = false,  Description = "Fortelling av turopplevelser"},
                new Blog {Name = "Tur til Afganistan", Closed = false,  Description = "Møtet med Taliban"},
                new Blog {Name = "Tur til USA", Closed = false,  Description = "Fortelling av turopplevelser"}
            };


            posts = new List<Post>
                {new Post { PostId = 1, PostText = "I dag har jeg besøkt Sydney og i morgen skal vi til Adelaide", BlogId = 1}
            };

            comments = new List<Comment>
                { new Comment { CommentId = 1, CommentText = "Så heldige dere er :)", PostId = 1}
            };


          
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
            repository.Setup(x => x.GetAllBlogs()).Returns(blogs);
            var controller = new BlogController(repository.Object);
            
            // Act
            var result = controller.Index() as ViewResult;

            // Assert                
            CollectionAssert.AllItemsAreInstancesOfType((ICollection) result.ViewData.Model, typeof(Blog));
            Assert.IsNotNull(result, "View Result is null");

            var blogsOriginal = result.ViewData.Model as List<Blog>;
            Assert.AreEqual(blogs.Count, blogsOriginal.Count, "Got wrong number of blogs");
        }

        [TestMethod]
        public void CreateReturnsNotNullResult()
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
            var result = controller.Create(new Blog());            
            
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

            var result = controller.Create(viewModel) as ViewResult;

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
            var result = controller.Create(viewModel) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result, "RedirectToIndex needs to redirect to the Index action");
            Assert.AreEqual("Index", result.ActionName);
        }
    }
}
