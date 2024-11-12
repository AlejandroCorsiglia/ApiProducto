using Dapper;
using MySql.Data.MySqlClient;
using Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Negocio
{
    public class ProductApi
    {
        string connStr = "Server=db4free.net;Database=lasnieves110424;Uid=lasnieves110424;Pwd=lasnieves110424;";
        public List<Product> GetProductos()
        {
          
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM `Products`";
                return conn.Query<Product>(sql).ToList();
            };


        }
        public Product GetProductoById(int id)


        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM `Products` where Id= @Id ";

                return conn.QueryFirstOrDefault<Product>(sql, new { Id = id });
            };
            
        }
      
        public int EliminarProducto(int id)
        {
            
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "DELETE FROM Products WHERE Id = @Id";
                conn.Execute(sql, new { Id = id });
                return id;



            }
        }
        public Product ModificarProducto(Product prod)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "UPDATE Products SET Title= @Title, Price = @Price, Category = @Category, Description = @Description WHERE Id = @Id";
                conn.Execute(sql,prod );
                return prod;

            }
           }
    
        public Product PostProducto(Product producto)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))

            {
                conn.Open();
                string sql = "INSERT INTO Products (Title, Price, Category, Description) VALUES(@Title, @Price, @Category, @Description )";
                conn.Execute(sql, producto);
                return producto;
            }
            
        }
        public List<string> GetCategories()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT Category FROM `Categories`";
                return conn.Query<string>(sql).ToList();
            }
        }

        public string PostCategorie(string category)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO Categories (Category) VALUES (@Category);";
                return conn.QueryFirstOrDefault<string>(sql, new { Category = category });
            }
        }

    }
}
