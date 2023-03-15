﻿using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class CategoriesLogic : BaseLogic, IABMLogic<Categories>
    {
        public List<Categories> GetAll()
        {
            return _nortwindContext.Categories.ToList();
        }

        public void Add(Categories newCategorie)
        {
            _nortwindContext.Categories.Add(newCategorie);

            _nortwindContext.SaveChanges();
        }

        public Categories ItemExist(int id)
        {
            var category =  _nortwindContext.Categories.Find(id);

            return category != null ? category : null;
        }

        public bool Delete(int id)
        {
            var category = ItemExist(id);


            if (category != null)
            {
                _nortwindContext.Categories.Remove(category);

                _nortwindContext.SaveChanges();

                return true;

            }

            throw new WrongIdException();
        }

        public void Update(Categories category)
        {
            var categoryExist = _nortwindContext.Categories.Find(category.CategoryID);

            categoryExist.CategoryName = category.CategoryName;
            categoryExist.Description = category.Description;

            _nortwindContext.SaveChanges();
        }
    }
}
