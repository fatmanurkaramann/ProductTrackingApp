﻿using DataAccess.Repositories.Abstraction;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : Repository<User, ProductTrackingDbContext>, IUserRepository
    {
        public UserRepository(ProductTrackingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
