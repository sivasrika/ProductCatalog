using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities
{
   public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

       

        public override string ToString()
        {
            return $"{ProductID}. {ProductName} - ${Price} (Stock: {StockQuantity})"; 
        }
    }
}
