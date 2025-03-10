﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepositories;

namespace Trips.Data.Repository
{
    public class AttractionRepository : Repository<Attraction>, IAttractionRepository
    {
        public AttractionRepository(DataContext dataContex) : base(dataContex)
        {

        }
        public async Task<List<Attraction>> GetAllAsync()
        {
            return await _dataSet.Include(x=>x.trips).ToListAsync();
        }
    }
}
