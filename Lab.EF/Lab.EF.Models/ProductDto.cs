using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Models
{
    public class ProductDto
    {
        public int productId { get; set; }

        public string productName { get; set; }

        public short? unitsInStock { get; set; }

        public int? categoryId { get; set;}
    }
}
