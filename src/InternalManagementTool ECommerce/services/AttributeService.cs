using ProductCatalog.Entities;
using ProductCatalog.Util;
using Microsoft.Data.SqlClient;

namespace ProductCatalog.Services
{
    public class AttributeService
    {
        public List<Attributes> GetByCategory(int categoryId)
        {
            var attributes = new List<Attributes>();
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("SELECT AttributeID, CategoryID, AttributeName, DataType FROM Attributes WHERE CategoryID = @catId", conn);
            cmd.Parameters.AddWithValue("@catId", categoryId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                attributes.Add(new Attributes
                {
                    AttributeID = reader.GetInt32(0),
                    CategoryID = reader.GetInt32(1),
                    AttributeName = reader.GetString(2),
                    DataType = reader.GetString(3)
                });
            }
            return attributes;
        }

        public Attributes? GetById(int attributeId)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("SELECT AttributeID, CategoryID, AttributeName, DataType FROM Attributes WHERE AttributeID = @id", conn);
            cmd.Parameters.AddWithValue("@id", attributeId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Attributes
                {
                    AttributeID = reader.GetInt32(0),
                    CategoryID = reader.GetInt32(1),
                    AttributeName = reader.GetString(2),
                    DataType = reader.GetString(3)
                };
            }
            return null;
        }

        public void Add(Attributes attribute)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("INSERT INTO Attributes (CategoryID, AttributeName, DataType) VALUES (@catId, @name, @type)", conn);
            cmd.Parameters.AddWithValue("@catId", attribute.CategoryID);
            cmd.Parameters.AddWithValue("@name", attribute.AttributeName);
            cmd.Parameters.AddWithValue("@type", attribute.DataType);
            cmd.ExecuteNonQuery();
        }

        public void Update(Attributes attribute)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("UPDATE Attributes SET AttributeName = @name, DataType = @type WHERE AttributeID = @id", conn);
            cmd.Parameters.AddWithValue("@name", attribute.AttributeName);
            cmd.Parameters.AddWithValue("@type", attribute.DataType);
            cmd.Parameters.AddWithValue("@id", attribute.AttributeID);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int attributeId)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("DELETE FROM Attributes WHERE AttributeID = @id", conn);
            cmd.Parameters.AddWithValue("@id", attributeId);
            cmd.ExecuteNonQuery();
        }

        // Custom: Get all distinct data types
        public List<string> GetDistinctDataTypes()
        {
            var types = new List<string>();
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("SELECT DISTINCT DataType FROM Attributes", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                types.Add(reader.GetString(0));
            }
            return types;
        }
    }
}
