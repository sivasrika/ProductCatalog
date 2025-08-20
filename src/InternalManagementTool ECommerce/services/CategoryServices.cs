using ProductCatalog.Entities;
using ProductCatalog.Util;
using Microsoft.Data.SqlClient;

namespace ProductCatalog.Services
{
    public class CategoryService
    {
        public List<Category> GetAll()
        {
            var categories = new List<Category>();
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("SELECT CategoryID, CategoryName, Description FROM Categories", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                categories.Add(new Category
                {
                    CategoryID = reader.GetInt32(0),
                    CategoryName = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? null : reader.GetString(2)
                });
            }
            return categories;
        }

        public Category? GetById(int categoryId)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("SELECT CategoryID, CategoryName, Description FROM Categories WHERE CategoryID = @id", conn);
            cmd.Parameters.AddWithValue("@id", categoryId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Category
                {
                    CategoryID = reader.GetInt32(0),
                    CategoryName = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? null : reader.GetString(2)
                };
            }
            return null;
        }

        public void Add(Category category)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("INSERT INTO Categories (CategoryName, Description) VALUES (@name, @desc)", conn);
            cmd.Parameters.AddWithValue("@name", category.CategoryName);
            cmd.Parameters.AddWithValue("@desc", category.Description ?? (object)DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public void Update(Category category)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("UPDATE Categories SET CategoryName = @name, Description = @desc WHERE CategoryID = @id", conn);
            cmd.Parameters.AddWithValue("@name", category.CategoryName);
            cmd.Parameters.AddWithValue("@desc", category.Description ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@id", category.CategoryID);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int categoryId)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("DELETE FROM Categories WHERE CategoryID = @id", conn);
            cmd.Parameters.AddWithValue("@id", categoryId);
            cmd.ExecuteNonQuery();
        }

        // Custom: Get category by name
        public Category? GetByName(string name)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("SELECT CategoryID, CategoryName, Description FROM Categories WHERE CategoryName = @name", conn);
            cmd.Parameters.AddWithValue("@name", name);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Category
                {
                    CategoryID = reader.GetInt32(0),
                    CategoryName = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? null : reader.GetString(2)
                };
            }
            return null;
        }
    }
}

