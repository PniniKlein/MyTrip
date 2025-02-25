﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepository;

namespace Trips.Core.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAllAsync(); 
    }
}
