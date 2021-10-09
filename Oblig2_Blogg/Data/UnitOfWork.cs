using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oblig2_Blogg.Models;
using Microsoft.EntityFrameworkCore;
using Oblig2_Blogg.Models.Entities;
using Oblig2_Blogg.Models.Repository;
/*
namespace Oblig2_Blogg.Data
{
    public class UnitOfWork : DbContext, IDisposable
    {
        public UnitOfWork(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        private ApplicationDbContext context = new ApplicationDbContext();
        private GenericRepository<Blog> departmentRepository;
        private GenericRepository<Post> courseRepository;

        public GenericRepository<Blog> DepartmentRepository
        {
            get
            {

                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Blog>(context);
                }
                return departmentRepository;
            }
        }

        public GenericRepository<Post> CourseRepository
        {
            get
            {

                if (this.courseRepository == null)
                {
                    this.courseRepository = new GenericRepository<Post>(context);
                }
                return courseRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
*/