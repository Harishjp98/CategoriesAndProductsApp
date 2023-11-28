using CategoriesAndProductsApp.Models;
using System.Linq.Expressions;

namespace CategoriesAndProductsApp.Repository.IRepository
{
   
        public interface ICategoryRepository
        {
     
        public IEnumerable<Category> GetAll();
        public bool Add(Category obj);
        public Category Get(int id);
        public bool Update(Category obj);
        public bool Delete(int id);
        }
    
}
