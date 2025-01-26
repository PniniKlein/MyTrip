using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.DTOs;
using Trips.Core.Entities;
using Trips.Core.IRepositories;
using Trips.Core.IRepository;
using Trips.Core.IService;

namespace Trips.Service.Servises
{
    public class AttractionService: IAttractionService
    {
        private readonly IRepositoryManager _iManager;
        private readonly IMapper _mapper;
        public AttractionService(IRepositoryManager iManager,IMapper mapper)
        {
            _iManager = iManager;
            _mapper = mapper;
        }
        public List<AttractionDto> Get()
        {
            List<Attraction> attractions = _iManager.IAttractionRep.Get();
            List<AttractionDto> attractionDtos = _mapper.Map<List<AttractionDto>>(attractions);
            return attractionDtos;
        }
        public List<Attraction> GetAll()
        {
            return _iManager.IAttractionRep.GetAll();
        }
        public AttractionDto? GetById(int id)
        {
            Attraction attraction = _iManager.IAttractionRep.GetById(id);
            AttractionDto attractionDto = _mapper.Map<AttractionDto>(attraction);
            return attractionDto;
        }

        public AttractionDto Add(AttractionDto attractionDto)
        {
            Attraction attraction = _mapper.Map<Attraction>(attractionDto);
            attraction = _iManager.IAttractionRep.Add(attraction);
            if (attraction!=null)
                _iManager.Save();
            attractionDto = _mapper.Map<AttractionDto>(attraction);
            return attractionDto;
        }
        public AttractionDto Update(int id, AttractionDto attractionDto)
        {
            Attraction attraction = _mapper.Map<Attraction>(attractionDto);
            attraction = _iManager.IAttractionRep.Update(id, attraction);
            if (attraction != null)
                _iManager.Save();
            attractionDto = _mapper.Map<AttractionDto>(attraction);
            return attractionDto;
        }
        public bool Delete(int id)
        {
            bool flag= _iManager.IAttractionRep.Delete(id);
            if (flag)
                _iManager.Save();
            return flag;
        }
    }
}
