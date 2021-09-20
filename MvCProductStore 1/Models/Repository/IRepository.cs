using MvCProductStore_1.Models.Entities;
using MvCProductStore_1.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using MvCProductStore_1.Data;

namespace MvCProductStore_1.Models.Repository
{
    public interface IRepository
    {
    
        IEnumerable<Product> GetAll();

       
        void Save(ProductEditViewModel product, IPrincipal principal);

        ProductEditViewModel GetProductEditViewModel();

        private static List<Contact> responses = new List<Contact>();

        public IEnumerable<Contact> Responses => responses;

        public void AddResponse(Contact response)
        {
            responses.Add(response);
        }
    }
}
