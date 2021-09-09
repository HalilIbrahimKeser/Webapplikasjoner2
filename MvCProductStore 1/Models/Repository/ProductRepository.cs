using MvCProductStore_1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvCProductStore_1.Models.Entities;
using MvCProductStore_1.Models.ViewModels;

namespace MvCProductStore_1.Models.Repository
{
    public class ProductRepository : IRepository
    {
        private ApplicationDbContext db;

        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> products = db.Products.Include("Category").Include("Manufacturer");
            return products;
        }

        public void Save(Product product)
        {
            product.modified = DateTime.Now;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }
        
        public void Save(ProductEditViewModel product)
        {
            Product productToSave = new Product();
            productToSave.Name = product.Name;
            productToSave.Description = product.Description;
            productToSave.Price = product.Price;
            productToSave.ManufacturerId = product.ManufacturerId;
            productToSave.CategoryId = product.CategoryId;

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
