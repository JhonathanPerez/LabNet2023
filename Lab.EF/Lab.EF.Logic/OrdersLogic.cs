using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class OrdersLogic : BaseLogic, IABMLogic<Orders>
    {
        public List<Orders> GetAll()
        {
            return _nortwindContext.Orders.ToList();
        }
    }
}
