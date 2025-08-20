using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities
{
    public class Attributes
    {
        public int AttributeID { get; set; }
        public int CategoryID { get; set; }
        public string AttributeName { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty; 
    }
}
