using Lab.EF.Entities;
using Lab.EF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class ShippersLogic : BaseLogic, IABMLogic<Shippers>
    {
        public void Add(Shippers newShipper)
        {
            _nortwindContext.Shippers.Add(newShipper);

            _nortwindContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var shipper = ItemExist(id);


            if (shipper != null)
            {
                _nortwindContext.Shippers.Remove(shipper);

                _nortwindContext.SaveChanges();

                return true;

            }

            throw new WrongIdException();
        }

        public List<Shippers> GetAll()
        {
            return _nortwindContext.Shippers.ToList();
        }

        public Shippers ItemExist(int id)
        {
            var shipper = _nortwindContext.Shippers.Find(id);

            return shipper != null ? shipper : null;
        }

        public Shippers ItemExist(string shipperName)
        {
            var shipper = _nortwindContext.Shippers.SingleOrDefault(name => name.CompanyName == shipperName);

            return shipper != null ? shipper : null;
        }

        public void Update(Shippers shipper)
        {
            var shipperExist = _nortwindContext.Shippers.Find(shipper.ShipperID);

            shipperExist.CompanyName = shipper.CompanyName;
            shipperExist.Phone = shipper.Phone;

            _nortwindContext.SaveChanges();
        }
    }
}
