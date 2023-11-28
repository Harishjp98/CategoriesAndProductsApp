using CategoriesAndProductsApp.Models;
using System.Linq.Expressions;

namespace CategoriesAndProductsApp.Repository.IRepository
{
   
        public interface IProductRepository
        {
        
        public IEnumerable<Products> GetAll();
        public bool Add(Products obj);
        public Products Get(int id);
        public bool Update(Products obj);
        public bool Delete(int id);
        }
    
}
