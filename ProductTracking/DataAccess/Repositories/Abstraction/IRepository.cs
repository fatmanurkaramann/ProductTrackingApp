﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstraction
{
    public interface IRepository<T>
    {
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        List<T> GetAll();
        T GetById(int id);
    }
}
