using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Models
{
    public class OrderDto
    {
        public int orderId { get; set; }

        public string customerId { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
