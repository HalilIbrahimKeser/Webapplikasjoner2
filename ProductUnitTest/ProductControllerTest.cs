using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvCProductStore_1.Controllers;
using MvCProductStore_1.Models.Entities;
using MvCProductStore_1.Models.Repository;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MvCProductStore_1.Models.ViewModels;

namespace ProductUnitTest
{
    [TestClass]
    public class ProductControllerTest
    {
        private Mock<IRepository> _repository;

        private List<Product> _products;
        private List<Category> _categories;
        private List<Manufacturer> _manufacturers;

        [TestInitialize]
        public void SetupContext()
        {
            _repository = new Mock<IRepository>();

            _categories = new List<Category>
                {new Category {CategoryId = 1, Name = "Verktøy"}, new Category {CategoryId = 2, Name = "Kjøretøy"}};

            _manufacturers = new List<Manufacturer>
                { new Manufacturer { ManufacturerId = 1, Name = "Volvo" }, new Manufacturer { ManufacturerId = 2, Name = "Bosch" }};


            _products = new List<Product>
            {
                new Product {Name = "Hammer", Price = 121.50m, CategoryId = 1, ManufacturerId = 2},
                new Product {Name = "Vinkelsliper", Price = 1520.00m, CategoryId = 1, ManufacturerId = 2},
                new Product {Name = "Volvo XC90", Price = 990000m, CategoryId = 2, ManufacturerId = 1},
                new Product {Name = "Volvo XC60", Price = 620000m, CategoryId = 2, ManufacturerId = 1},
                new Product {Name = "Volvo S80", Price = 125000m, CategoryId = 2, ManufacturerId = 1}
            };
        }


        [TestMethod]
        public void CreateRedirectActionRedirectsToIndexAction()
        {
            //Arrange
            var mockRepo = new Mock<IRepository>();
            var controller = new ProductController(mockRepo.Object);
            controller.ControllerContext = MockHelpers.FakeControllerContext(false);
            var tempData = new TempDataDictionary(controller.ControllerContext.HttpContext, Mock.Of<ITempDataProvider>());
            controller.TempData = tempData;
            var model = new ProductEditViewModel();
            model.Price = 100;
            model.Description = "Description of product";

            //Act
            var result = controller.Create(model) as RedirectToActionResult;

            //Assert
            Assert.IsNotNull(result, "RedirectToIndex needs to redirect to the Index action");
            Assert.AreEqual("Index", result.ActionName as String);

        }

        [TestMethod]
        public void IndexReturnsAllProducts()
        {
            // Arrange
            _repository.Setup(x => x.GetAll()).Returns(_products);
            var controller = new ProductController(_repository.Object);

            // Act
            var result = (ViewResult)controller.Index();

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(Product));
            Assert.IsNotNull(result, "View Result is null");
            var products = result.ViewData.Model as List<Product>;
            Assert.AreEqual(5, products.Count, "Got wrong number of products");
        }

        /*
        [TestMethod]
        public void SaveIsCalledWhenProductIsCreated() 
        {
            // Arrange
            _repository.Setup(x => x.Save(It.IsAny<ProductEditViewModel>()));
            var controller = new ProductController(_repository.Object);

            // Act
            var result = controller.Create();

            // Assert
            _repository.VerifyAll();
            // test på at save er kalt et bestemt antall ganger
            //_repository.Verify(x => x.Save(It.IsAny<ProductEditViewModel>()), Times.Exactly(1));
        }
        */


        [TestMethod]
        public void IndexReturnsNotNullResult()
        {
            // Arrange
            _repository = new Mock<IRepository>();
            var controller = new ProductController(_repository.Object);
            // Act
            var result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result, "View Result is null");

        }

        [TestMethod]
        public void CreateReturnsNotNullResult()
        {
            // Arrange
            var controller = new ProductController(_repository.Object);

            // Act
            var result = (ViewResult)controller.Create();

            // Assert
            Assert.IsNotNull(result, "View Result is null");
        }

        [TestMethod]
        public void CreateViewIsReturnedWhenInputIsNotValid()
        {
            // Arrange
            var viewModel = new ProductEditViewModel()
            {
                Name = "",
                Description = "",
                Price = 0
            };
            var controller = new ProductController(_repository.Object);

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
    }
}
