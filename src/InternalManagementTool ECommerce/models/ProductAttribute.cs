using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities
{
   public class ProductAttribute
    {
        public int ValueID { get; set; }
        public int ProductID { get; set; }
        public int AttributeID { get; set; }
        public string AttributeValue { get; set; } = string.Empty;
    }
}
