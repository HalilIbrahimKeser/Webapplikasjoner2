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

namespace BlogTest
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IRepository> repository;

        private List<Blog> blogs;
        private List<Post> posts;
        private List<Comment> comments;

        [TestInitialize]
        public void SetupContext()
        {
            repository = new Mock<IRepository>();
            string dateString = "Sep 17, 2021";
            string dateString1 = "Sep 18, 2021";
            string dateString2 = "Sep 19, 2021";
            DateTime dateCreated = DateTime.Parse(dateString);
            DateTime dateCreated1 = DateTime.Parse(dateString1);
            DateTime dateCreated2 = DateTime.Parse(dateString2);

            posts = new List<Post>
                {new Post { PostId = 1, PostText = "I dag har jeg besøkt Sydney og i morgen skal vi til Adelaide", BlogId = 1}};

            comments = new List<Comment>
                { new Comment { CommentId = 1, CommentText = "Så heldige dere er :)", PostId = 1}};


            blogs = new List<Blog>
            {
                new Blog {Name = "Tur til Australia", Closed = false,  Description = "Fortelling av turopplevelser"},
                new Blog {Name = "Tur til Somalia", Closed = false,  Description = "Fortelling av turopplevelser"},
                new Blog {Name = "Tur til Afganistan", Closed = false,  Description = "Møtet med Taliban"},
                new Blog {Name = "Tur til USA", Closed = false,  Description = "Fortelling av turopplevelser"}
            };
        }

        [TestMethod]
        public void IndexReturnsNotNullResult()
        {
            // Arrange
            repository = new Mock<IRepository>();
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
            Mock<IRepository> _repository2 = new Mock<IRepository>();

            List<Blog> fakeBlogs = new List<Blog>
            {
                new Blog {Name = "Tur til Australia", Closed = false,  Description = "Fortelling av turopplevelser"},
                new Blog {Name = "Tur til Somalia", Closed = false,  Description = "Fortelling av turopplevelser"},
                new Blog {Name = "Tur til Afganistan", Closed = false,  Description = "Møtet med Taliban"},
                new Blog {Name = "Tur til USA", Closed = false,  Description = "Fortelling av turopplevelser"}
            };
            _repository2.Setup(x => x.GetAll()).Returns(fakeBlogs);
            var controller = new BlogController(_repository2.Object);
            
            // Act
            var result = (ViewResult)controller.Index(); 
            
            // Assert
            Debug.Assert(result != null, nameof(result) + " != null");
            
            CollectionAssert.AllItemsAreInstancesOfType((ICollection) result.ViewData.Model, typeof(Blog));
            Assert.IsNotNull(result, "View Result is null");
            
            var blogs = result.ViewData.Model as List<Blog>;
            Debug.Assert(blogs != null, nameof(blogs) + " != null");
            
            Assert.AreEqual(4, blogs.Count, "Got wrong number of blogs");
        }

        [TestMethod]
        public void SaveIsCalledWhenProductIsCreated()
        { 
            // Arrange
            //repository = new Mock<IRepository>();
            //repository.Setup(x => x.Save(It.IsAny<Blog>()));
            var controller = new BlogController(repository.Object);
            
            
            // Act
            var result = controller.Create(new Blog());
            
            
            // Assert
            //TODO
            //repository.VerifyAll();
            // test på at save er kalt et bestemt antall ganger
            repository.Verify(x => x.Save(It.IsAny<Blog>(), new ClaimsPrincipal()), Times.Exactly(1));
        }
    }
}
