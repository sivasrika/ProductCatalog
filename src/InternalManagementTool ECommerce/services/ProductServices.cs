using ProductCatalog.Entities;
using ProductCatalog.Util;
using Microsoft.Data.SqlClient;

namespace ProductCatalog.Services
{
    public class ProductService
    {
        public List<Product> GetAll()
        {
            var products = new List<Product>();
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("SELECT ProductID, CategoryID, ProductName, Price, StockQuantity FROM Products", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    ProductID = reader.GetInt32(0),
                    CategoryID = reader.GetInt32(1),
                    ProductName = reader.GetString(2),
                    Price = reader.GetDecimal(3),
                    StockQuantity = reader.GetInt32(4)
                });
            }
            return products;
        }

        public Product? GetById(int productId)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("SELECT ProductID, CategoryID, ProductName, Price, StockQuantity FROM Products WHERE ProductID = @id", conn);
            cmd.Parameters.AddWithValue("@id", productId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Product
                {
                    ProductID = reader.GetInt32(0),
                    CategoryID = reader.GetInt32(1),
                    ProductName = reader.GetString(2),
                    Price = reader.GetDecimal(3),
                    StockQuantity = reader.GetInt32(4)
                };
            }
            return null;
        }

        public void Add(Product product)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("INSERT INTO Products (CategoryID, ProductName, Price, StockQuantity) VALUES (@catId, @name, @price, @qty)", conn);
            cmd.Parameters.AddWithValue("@catId", product.CategoryID);
            cmd.Parameters.AddWithValue("@name", product.ProductName);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@qty", product.StockQuantity);
            cmd.ExecuteNonQuery();
        }

        public void Update(Product product)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("UPDATE Products SET CategoryID = @catId, ProductName = @name, Price = @price, StockQuantity = @qty WHERE ProductID = @id", conn);
            cmd.Parameters.AddWithValue("@catId", product.CategoryID);
            cmd.Parameters.AddWithValue("@name", product.ProductName);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@qty", product.StockQuantity);
            cmd.Parameters.AddWithValue("@id", product.ProductID);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int productId)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("DELETE FROM Products WHERE ProductID = @id", conn);
            cmd.Parameters.AddWithValue("@id", productId);
            cmd.ExecuteNonQuery();
        }

        // Custom: Get products by category
        public List<Product> GetByCategory(int categoryId)
        {
            var products = new List<Product>();
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("SELECT ProductID, CategoryID, ProductName, Price, StockQuantity FROM Products WHERE CategoryID = @catId", conn);
            cmd.Parameters.AddWithValue("@catId", categoryId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    ProductID = reader.GetInt32(0),
                    CategoryID = reader.GetInt32(1),
                    ProductName = reader.GetString(2),
                    Price = reader.GetDecimal(3),
                    StockQuantity = reader.GetInt32(4)
                });
            }
            return products;
        }
    }
}
