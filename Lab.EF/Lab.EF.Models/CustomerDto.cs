using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Models
{
    public class CustomerDto
    {
        public string customerId { get; set; }

        public string companyName { get; set; }

        public string contactName { get; set; }

        public string customerAdress { get; set; }

        public string customerCity { get; set; }

        public string customerPhone { get; set; }

        public string customerRegion { get; set; }

        public DateTime? OrderDate { get; set; }

        public int customerCountOrders { get; set; }
    }
}
