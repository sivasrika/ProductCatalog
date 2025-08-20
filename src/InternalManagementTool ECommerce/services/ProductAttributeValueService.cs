using ProductCatalog.Entities;
using ProductCatalog.Util;
using Microsoft.Data.SqlClient;

namespace ProductCatalog.Services
{
    public class ProductAttributeValueService
    {
        public List<ProductAttribute> GetByProduct(int productId)
        {
            var values = new List<ProductAttribute>();
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("SELECT ValueID, ProductID, AttributeID, AttributeValue FROM ProductAttributeValues WHERE ProductID = @prodId", conn);
            cmd.Parameters.AddWithValue("@prodId", productId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                values.Add(new ProductAttribute
                {
                    ValueID = reader.GetInt32(0),
                    ProductID = reader.GetInt32(1),
                    AttributeID = reader.GetInt32(2),
                    AttributeValue = reader.GetString(3)
                });
            }
            return values;
        }

        public ProductAttribute? GetById(int valueId)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("SELECT ValueID, ProductID, AttributeID, AttributeValue FROM ProductAttributeValues WHERE ValueID = @id", conn);
            cmd.Parameters.AddWithValue("@id", valueId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new ProductAttribute
                {
                    ValueID = reader.GetInt32(0),
                    ProductID = reader.GetInt32(1),
                    AttributeID = reader.GetInt32(2),
                    AttributeValue = reader.GetString(3)
                };
            }
            return null;
        }

        public void Add(ProductAttribute value)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("INSERT INTO ProductAttributeValues (ProductID, AttributeID, AttributeValue) VALUES (@prodId, @attrId, @val)", conn);
            cmd.Parameters.AddWithValue("@prodId", value.ProductID);
            cmd.Parameters.AddWithValue("@attrId", value.AttributeID);
            cmd.Parameters.AddWithValue("@val", value.AttributeValue);
            cmd.ExecuteNonQuery();
        }

        public void Update(ProductAttribute value)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("UPDATE ProductAttributeValues SET ProductID = @prodId, AttributeID = @attrId, AttributeValue = @val WHERE ValueID = @id", conn);
            cmd.Parameters.AddWithValue("@prodId", value.ProductID);
            cmd.Parameters.AddWithValue("@attrId", value.AttributeID);
            cmd.Parameters.AddWithValue("@val", value.AttributeValue);
            cmd.Parameters.AddWithValue("@id", value.ValueID);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int valueId)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("DELETE FROM ProductAttributeValues WHERE ValueID = @id", conn);
            cmd.Parameters.AddWithValue("@id", valueId);
            cmd.ExecuteNonQuery();
        }

        // Custom: Get all attribute values for a given attribute
        public List<ProductAttribute> GetByAttribute(int attributeId)
        {
            var values = new List<ProductAttribute>();
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("SELECT ValueID, ProductID, AttributeID, AttributeValue FROM ProductAttributeValues WHERE AttributeID = @attrId", conn);
            cmd.Parameters.AddWithValue("@attrId", attributeId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                values.Add(new ProductAttribute
                {
                    ValueID = reader.GetInt32(0),
                    ProductID = reader.GetInt32(1),
                    AttributeID = reader.GetInt32(2),
                    AttributeValue = reader.GetString(3)
                });
            }
            return values;
        }
    }
}
