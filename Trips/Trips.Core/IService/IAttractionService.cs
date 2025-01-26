using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.DTOs;
using Trips.Core.Entities;

namespace Trips.Core.IService
{
    public interface IAttractionService
    {
        List<AttractionDto> Get();
        List<Attraction> GetAll();
        AttractionDto GetById(int id);
        AttractionDto Add(AttractionDto attractionDto);
        AttractionDto Update(int id, AttractionDto attractionDto);
        bool Delete(int id);
    }
}
