using ProductCatalog.Entities;
using ProductCatalog.Services;

class Program
{
    static void Main()
    {
        var categoryService = new CategoryService();
        var attributeService = new AttributeService();
        var productService = new ProductService();
        var valueService = new ProductAttributeValueService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Product Catalog Management ===");
            Console.WriteLine("1. Manage Categories");
            Console.WriteLine("2. Manage Attributes");
            Console.WriteLine("3. Manage Products");
            Console.WriteLine("4. Manage Product Attribute Values");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ManageCategories(categoryService);
                    break;
                case "2":
                    ManageAttributes(attributeService);
                    break;
                case "3":
                    ManageProducts(productService);
                    break;
                case "4":
                    ManageProductAttributeValues(valueService);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void ManageCategories(CategoryService service)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Manage Categories ===");
            Console.WriteLine("1. List Categories");
            Console.WriteLine("2. Add Category");
            Console.WriteLine("3. Update Category");
            Console.WriteLine("4. Delete Category");
            Console.WriteLine("0. Back");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    var categories = service.GetAll();
                    Console.WriteLine("ID\tName\tDescription");
                    foreach (var c in categories)
                        Console.WriteLine($"{c.CategoryID}\t{c.CategoryName}\t{c.Description}");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Write("Category Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Description: ");
                    var desc = Console.ReadLine();
                    service.Add(new Category { CategoryName = name, Description = desc });
                    Console.WriteLine("Category added. Press Enter to continue...");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Category ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        var cat = service.GetById(updateId);
                        if (cat != null)
                        {
                            Console.Write($"New Name ({cat.CategoryName}): ");
                            var newName = Console.ReadLine();
                            Console.Write($"New Description ({cat.Description}): ");
                            var newDesc = Console.ReadLine();
                            cat.CategoryName = string.IsNullOrWhiteSpace(newName) ? cat.CategoryName : newName;
                            cat.Description = string.IsNullOrWhiteSpace(newDesc) ? cat.Description : newDesc;
                            service.Update(cat);
                            Console.WriteLine("Category updated. Press Enter to continue...");
                        }
                        else
                        {
                            Console.WriteLine("Category not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Write("Category ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        service.Delete(deleteId);
                        Console.WriteLine("Category deleted. Press Enter to continue...");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    Console.ReadLine();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void ManageAttributes(AttributeService service)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Manage Attributes ===");
            Console.WriteLine("1. List Attributes by Category");
            Console.WriteLine("2. Add Attribute");
            Console.WriteLine("3. Update Attribute");
            Console.WriteLine("4. Delete Attribute");
            Console.WriteLine("0. Back");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Category ID: ");
                    if (int.TryParse(Console.ReadLine(), out int catId))
                    {
                        var attrs = service.GetByCategory(catId);
                        Console.WriteLine("ID\tName\tDataType");
                        foreach (var a in attrs)
                            Console.WriteLine($"{a.AttributeID}\t{a.AttributeName}\t{a.DataType}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Write("Category ID: ");
                    if (int.TryParse(Console.ReadLine(), out int addCatId))
                    {
                        Console.Write("Attribute Name: ");
                        var attrName = Console.ReadLine();
                        Console.Write("Data Type: ");
                        var dataType = Console.ReadLine();
                        service.Add(new Attributes { CategoryID = addCatId, AttributeName = attrName, DataType = dataType });
                        Console.WriteLine("Attribute added. Press Enter to continue...");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Category ID.");
                    }
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Attribute ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        var attr = service.GetById(updateId);
                        if (attr != null)
                        {
                            Console.Write($"New Name ({attr.AttributeName}): ");
                            var newName = Console.ReadLine();
                            Console.Write($"New DataType ({attr.DataType}): ");
                            var newType = Console.ReadLine();
                            attr.AttributeName = string.IsNullOrWhiteSpace(newName) ? attr.AttributeName : newName;
                            attr.DataType = string.IsNullOrWhiteSpace(newType) ? attr.DataType : newType;
                            service.Update(attr);
                            Console.WriteLine("Attribute updated. Press Enter to continue...");
                        }
                        else
                        {
                            Console.WriteLine("Attribute not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Write("Attribute ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        service.Delete(deleteId);
                        Console.WriteLine("Attribute deleted. Press Enter to continue...");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    Console.ReadLine();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void ManageProducts(ProductService service)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Manage Products ===");
            Console.WriteLine("1. List Products");
            Console.WriteLine("2. List Products by Category");
            Console.WriteLine("3. Add Product");
            Console.WriteLine("4. Update Product");
            Console.WriteLine("5. Delete Product");
            Console.WriteLine("0. Back");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    var products = service.GetAll();
                    Console.WriteLine("ID\tName\tCategoryID\tPrice\tStock");
                    foreach (var p in products)
                        Console.WriteLine($"{p.ProductID}\t{p.ProductName}\t{p.CategoryID}\t{p.Price}\t{p.StockQuantity}");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Write("Category ID: ");
                    if (int.TryParse(Console.ReadLine(), out int catId))
                    {
                        var productsByCat = service.GetByCategory(catId);
                        Console.WriteLine("ID\tName\tPrice\tStock");
                        foreach (var p in productsByCat)
                            Console.WriteLine($"{p.ProductID}\t{p.ProductName}\t{p.Price}\t{p.StockQuantity}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Category ID: ");
                    if (int.TryParse(Console.ReadLine(), out int addCatId))
                    {
                        Console.Write("Product Name: ");
                        var prodName = Console.ReadLine();
                        Console.Write("Price: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal price))
                        {
                            Console.Write("Stock Quantity: ");
                            if (int.TryParse(Console.ReadLine(), out int stock))
                            {
                                service.Add(new Product { CategoryID = addCatId, ProductName = prodName, Price = price, StockQuantity = stock });
                                Console.WriteLine("Product added. Press Enter to continue...");
                            }
                            else
                            {
                                Console.WriteLine("Invalid stock quantity.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid price.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Category ID.");
                    }
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Write("Product ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        var prod = service.GetById(updateId);
                        if (prod != null)
                        {
                            Console.Write($"New Name ({prod.ProductName}): ");
                            var newName = Console.ReadLine();
                            Console.Write($"New Price ({prod.Price}): ");
                            var newPriceStr = Console.ReadLine();
                            Console.Write($"New Stock ({prod.StockQuantity}): ");
                            var newStockStr = Console.ReadLine();

                            prod.ProductName = string.IsNullOrWhiteSpace(newName) ? prod.ProductName : newName;
                            if (decimal.TryParse(newPriceStr, out decimal newPrice)) prod.Price = newPrice;
                            if (int.TryParse(newStockStr, out int newStock)) prod.StockQuantity = newStock;

                            service.Update(prod);
                            Console.WriteLine("Product updated. Press Enter to continue...");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    Console.ReadLine();
                    break;
                case "5":
                    Console.Write("Product ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        service.Delete(deleteId);
                        Console.WriteLine("Product deleted. Press Enter to continue...");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    Console.ReadLine();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void ManageProductAttributeValues(ProductAttributeValueService service)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Manage Product Attribute Values ===");
            Console.WriteLine("1. List Attribute Values by Product");
            Console.WriteLine("2. List Attribute Values by Attribute");
            Console.WriteLine("3. Add Attribute Value");
            Console.WriteLine("4. Update Attribute Value");
            Console.WriteLine("5. Delete Attribute Value");
            Console.WriteLine("0. Back");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Product ID: ");
                    if (int.TryParse(Console.ReadLine(), out int prodId))
                    {
                        var values = service.GetByProduct(prodId);
                        Console.WriteLine("ValueID\tAttributeID\tValue");
                        foreach (var v in values)
                            Console.WriteLine($"{v.ValueID}\t{v.AttributeID}\t{v.AttributeValue}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Product ID.");
                    }
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Write("Attribute ID: ");
                    if (int.TryParse(Console.ReadLine(), out int attrId))
                    {
                        var values = service.GetByAttribute(attrId);
                        Console.WriteLine("ValueID\tProductID\tValue");
                        foreach (var v in values)
                            Console.WriteLine($"{v.ValueID}\t{v.ProductID}\t{v.AttributeValue}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Attribute ID.");
                    }
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Write("Product ID: ");
                    if (int.TryParse(Console.ReadLine(), out int addProdId))
                    {
                        Console.Write("Attribute ID: ");
                        if (int.TryParse(Console.ReadLine(), out int addAttrId))
                        {
                            Console.Write("Attribute Value: ");
                            var value = Console.ReadLine();
                            service.Add(new ProductAttribute { ProductID = addProdId, AttributeID = addAttrId, AttributeValue = value });
                            Console.WriteLine("Attribute value added. Press Enter to continue...");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Attribute ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Product ID.");
                    }
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Write("Value ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        var val = service.GetById(updateId);
                        if (val != null)
                        {
                            Console.Write($"New Product ID ({val.ProductID}): ");
                            var newProdStr = Console.ReadLine();
                            Console.Write($"New Attribute ID ({val.AttributeID}): ");
                            var newAttrStr = Console.ReadLine();
                            Console.Write($"New Value ({val.AttributeValue}): ");
                            var newValue = Console.ReadLine();

                            if (int.TryParse(newProdStr, out int newProdId)) val.ProductID = newProdId;
                            if (int.TryParse(newAttrStr, out int newAttrId)) val.AttributeID = newAttrId;
                            val.AttributeValue = string.IsNullOrWhiteSpace(newValue) ? val.AttributeValue : newValue;

                            service.Update(val);
                            Console.WriteLine("Attribute value updated. Press Enter to continue...");
                        }
                        else
                        {
                            Console.WriteLine("Value not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    Console.ReadLine();
                    break;
                case "5":
                    Console.Write("Value ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        service.Delete(deleteId);
                        Console.WriteLine("Attribute value deleted. Press Enter to continue...");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    Console.ReadLine();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
