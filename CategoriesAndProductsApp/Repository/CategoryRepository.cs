
using CategoriesAndProductsApp.Models;
using CategoriesAndProductsApp.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography;
namespace CategoriesAndProductsApp.Repository
{
   
    public class CategoryRepository: ICategoryRepository
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;

        private static IConfiguration _config;


        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory
                .GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _config= builder.Build();
            return _config.GetConnectionString("DefaultConnection");

        }

        public IEnumerable<Category> GetAll()
        {
            var categoryList =new List<Category>();
            using(_connection =new SqlConnection (GetConnectionString()))
            {
               _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[sp_GetAllCategories]";
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();
                while(dr.Read())
                {
                    Category obj = new Category();  
                    obj.ID = Convert.ToInt32(dr["ID"]); ;
                    obj.Name = dr["Name"].ToString();
                    obj.DisplayOrder = Convert.ToInt32(dr["DisplayOrder"]);
                    obj.CreatedDateTime = Convert.ToDateTime(dr["CreatedDateTime"]);

                    categoryList.Add(obj);
                }
                _connection.Close();
            }
            return categoryList;
        }

        public bool Add(Category obj)
        {
            int result = 0;
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[sp_AddCategory]";
                _command.Parameters.AddWithValue("@Name", obj.Name);
                _command.Parameters.AddWithValue("@DisplayOrder", obj.DisplayOrder);
                _connection.Open();
                result = _command.ExecuteNonQuery();
                _connection.Close();
            }
            return result > 0 ? true : false;
        }

        public Category Get(int id)
        {
            var categoryObj = new Category();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[sp_GetCategoryById]";
                _command.Parameters.AddWithValue("@CategoryId", id);
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();
                while (dr.Read())
                {
                    categoryObj.ID = Convert.ToInt32(dr["ID"]); ;
                    categoryObj.Name = dr["Name"].ToString();
                    categoryObj.DisplayOrder = Convert.ToInt32(dr["DisplayOrder"]);
                    categoryObj.CreatedDateTime = Convert.ToDateTime(dr["CreatedDateTime"]);
      
                }
                _connection.Close();
            }
            return categoryObj;
        }


        public bool Update(Category obj)
        {
            int result = 0;
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[sp_UpdateCategory]";
                _command.Parameters.AddWithValue("@CategoryId", obj.ID);
                _command.Parameters.AddWithValue("@Name", obj.Name);
                _command.Parameters.AddWithValue("@DisplayOrder", obj.DisplayOrder);
                _connection.Open();
                result = _command.ExecuteNonQuery();
                _connection.Close();
            }
            return result > 0 ? true : false;
        }

        public bool Delete(int id)
        {
            int result =0;
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[sp_DeleteCategory]";
                _command.Parameters.AddWithValue("@CategoryId",id);             
                _connection.Open();
                result = _command.ExecuteNonQuery();
                _connection.Close();
            }
           return result> 0 ? true : false;
        }

    }
}
