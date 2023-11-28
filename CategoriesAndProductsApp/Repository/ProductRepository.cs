
using CategoriesAndProductsApp.Models;
using CategoriesAndProductsApp.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography;

namespace CategoriesAndProductsApp.Repository
{
    
    public class ProductRepository: IProductRepository
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

        public IEnumerable<Products> GetAll()
        {
            var productObjList =new List<Products>();
            using(_connection =new SqlConnection (GetConnectionString()))
            {
               _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[sp_GetAllProducts]";
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();
                while(dr.Read())
                {
                    Products obj = new Products();  
                    obj.Id = Convert.ToInt32(dr["ID"]); ;
                    obj.Title = dr["Title"].ToString();
                    obj.Description = dr["Description"].ToString();
                    obj.Price = Convert.ToDouble(dr["Price"]);
                    obj.CategoryId = Convert.ToInt32(dr["categoryId"]);
                    obj.Category = dr["Name"].ToString();

                    productObjList.Add(obj);
                }
                _connection.Close();
            }
            return productObjList;
        }

        public bool Add(Products obj)
        {
            int result = 0;
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[sp_AddProduct]";
                _command.Parameters.AddWithValue("@Title", obj.Title);
                _command.Parameters.AddWithValue("@Description", obj.Description);
                _command.Parameters.AddWithValue("@Price", obj.Price);
                _command.Parameters.AddWithValue("@Category", obj.CategoryId);
                _connection.Open();
                result = _command.ExecuteNonQuery();
                _connection.Close();
            }
            return result > 0 ? true : false;
        }

        public Products Get(int id)
        {
            var productObj = new Products();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[sp_GetProductById]";
                _command.Parameters.AddWithValue("@ProductId", id);
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();
                while (dr.Read())
                {
                    productObj.Id = Convert.ToInt32(dr["ID"]); ;
                    productObj.Title = dr["Title"].ToString();
                    productObj.Description = dr["Description"].ToString();    
                    productObj.Price = Convert.ToDouble(dr["Price"]);
                    productObj.CategoryId = Convert.ToInt32(dr["categoryId"]);
                    productObj.Category = dr["Name"].ToString();

                }
                _connection.Close();
            }
            return productObj;
        }


        public bool Update(Products obj)
        {
            int result = 0;
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[sp_UpdateProduct]";
                _command.Parameters.AddWithValue("@ProductId", obj.Id);
                _command.Parameters.AddWithValue("@Title", obj.Title);
                _command.Parameters.AddWithValue("@Description", obj.Description);
                _command.Parameters.AddWithValue("@Price", obj.Price);
                _command.Parameters.AddWithValue("@Category", obj.CategoryId);
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
                _command.CommandText = "[DBO].[sp_DeleteProduct]";
                _command.Parameters.AddWithValue("@ProductId", id);             
                _connection.Open();
                result = _command.ExecuteNonQuery();
                _connection.Close();
            }
           return result> 0 ? true : false;
        }

    }
}
