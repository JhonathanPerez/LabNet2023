﻿using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public interface IABMLogic<T>
    {
        List<T> GetAll();

        void Add(T type);

        T ItemExist(int id);

        T ItemExist(string name);

        bool Delete(int id);

        void Update(T entity);


       


    }
}
