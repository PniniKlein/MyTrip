﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;

namespace Trips.Core.IRepository
{
    public interface IRepository<T>
    {
        List<T> Get();
        T GetById(int id);
        T Add(T user);
        T Update(int id, T user);
        bool Delete(int id);
    }
}
