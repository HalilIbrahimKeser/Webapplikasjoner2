using MvCProductStore_1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvCProductStore_1.Models.Entities;
using MvCProductStore_1.Models.ViewModels;
using System.Security.Claims;
using System.Security.Principal;

namespace MvCProductStore_1.Models.Repository
{
    public class ProductRepository : IRepository
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> manager;

        public ProductRepository(UserManager<IdentityUser> userManager, ApplicationDbContext db)
        {
            this.db = db;
            this.manager = userManager;
        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> products = db.Products.Include("Category").Include("Manufacturer");
            return products;
        }
        /*
        [Authorize]
        public async Task Save(Product product, IPrincipal principal)
        {
            var owner =  manager.FindByNameAsync(principal.Identity.Name);
            product.Owner = owner.Result;
            product.modified = DateTime.Now;
            db.Entry(product).State = EntityState.Modified;
            db.Products.Add(product);
            db.SaveChanges();
        }
        */
        [Authorize]
        void IRepository.Save(ProductEditViewModel product, IPrincipal principal)
        {
            var currentUser = manager.FindByNameAsync(principal.Identity.Name);
            Product productToSave = new Product();
            productToSave.Name = product.Name;
            productToSave.Description = product.Description;
            productToSave.Price = product.Price;
            productToSave.ManufacturerId = product.ManufacturerId;
            productToSave.CategoryId = product.CategoryId;
            productToSave.Owner = currentUser.Result;

            db.Add(productToSave);
            db.SaveChanges();
        }



        public ProductEditViewModel GetProductEditViewModel()
        {
            var productEditViewModel = new ProductEditViewModel
            {
                Categories = GetAllCategories().ToList(),
                Manufacturers = GetAllManufacturers().ToList()
            };
            return productEditViewModel;

        }

        private IEnumerable<Manufacturer> GetAllManufacturers()
        {
            var query = from manufacturer in db.Manufacturers
                select manufacturer;
            return query;
        }

        private IEnumerable<Category> GetAllCategories()
        {
            var query = from category in db.Categories
                select category;

            return query;
        }

      
    }
}
