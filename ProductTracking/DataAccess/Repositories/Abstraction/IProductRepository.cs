﻿using DataAccess.Abstraction;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstraction
{
    public interface IProductRepository:IRepository<Product>
    {
        void UpdatePrice(int productId, decimal newPrice);
    }
}
