using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities
{
   public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }

      

        public override string ToString()
        {
            return $"{CategoryID}. {CategoryName} - {Description} )";
        } 

    }
}
