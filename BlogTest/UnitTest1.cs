using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Oblig2_Blogg.Controllers;
using Oblig2_Blogg.Models;
using Oblig2_Blogg.Models.Entities;

namespace BlogTest
{
    [TestClass]
    public class UnitTest1
    {
        IBlogRepository _repository1;
        Mock<IBlogRepository> _repository;


        [TestMethod]
        public void IndexReturnsNotNullResult()
        {
            // Arrange
            _repository1 = new FakeBlogRepository();
            var controller = new BlogController(_repository1);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result, "View Result is null");
        }

        [TestMethod]
        public void IndexReturnsAllBlogs()
        {
            // Arrange
            Mock<IBlogRepository> _repository2 = new Mock<IBlogRepository>();

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
            
            Assert.AreEqual(4, blogs.Count, "Got wrong number of products");
        }

        [TestMethod]
        public void SaveIsCalledWhenProductIsCreated()
        { 
            // Arrange
            _repository = new Mock<IBlogRepository>();
            _repository.Setup(x => x.Save(It.IsAny<Blog>()));
            var controller = new BlogController(_repository.Object);
            
            
            // Act
            var result = controller.Create(new Blog());
            
            
            // Assert
            _repository.VerifyAll();
            // test på at save er kalt et bestemt antall ganger
            //_repository.Verify(x => x.save(It.IsAny<Product>()), Times.Exactly(1));
        }
    }
}
