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
    public class GuideService : IGuideService
    {
        readonly IRepositoryManager _iManager;
        private readonly IMapper _mapper;
        public GuideService(IRepositoryManager iManager,IMapper mapper)
        {
            _iManager = iManager;
            _mapper = mapper;
        }
        public List<GuideDto> Get()
        {
            List<Guide> guides = _iManager.IGuideRep.Get();
            List<GuideDto> guideDtos = _mapper.Map<List<GuideDto>>(guides);
            return guideDtos;
        }
        public List<Guide> GetAll()
        {
            return _iManager.IGuideRep.GetAll();
        }
        public GuideDto? GetById(int id)
        {
            Guide guide = _iManager.IGuideRep.GetById(id);
            GuideDto guideDto = _mapper.Map<GuideDto>(guide);
            return guideDto;
        }

        public GuideDto Add(GuideDto guideDto)
        {
            if (!CorrectTZ(guideDto.TZ))
                return null;
            Guide guide = _mapper.Map<Guide>(guideDto);
            guide= _iManager.IGuideRep.Add(guide);
            if (guide != null)
                _iManager.Save();
            guideDto = _mapper.Map<GuideDto>(guide);
            return guideDto;
        }
        public GuideDto Update(int id, GuideDto guideDto)
        {
            if (!CorrectTZ(guideDto.TZ))
                return null;
            Guide guide = _mapper.Map<Guide>(guideDto);
            guide = _iManager.IGuideRep.Update(id, guide);
            if (guide != null)
                _iManager.Save();
            guideDto = _mapper.Map<GuideDto>(guide);
            return guideDto;
        }
        public bool Delete(int id)
        {
            bool flag= _iManager.IGuideRep.Delete(id);
            if (flag)
              _iManager.Save();
            return flag;
        }

        public bool CorrectTZ(string TZ)
        {
            if (TZ.Length != 9)
                return false;
            int sum = 0;
            for (int i = 0; i < 8; i++)
            {
                if (TZ[i] < '0' || TZ[i] > '9')
                    return false;
                if (i % 2 == 0)
                    sum += TZ[i] - '0';
                else
                    sum += (TZ[i] - '0') * 2 % 10 + (TZ[i] - '0') * 2 / 10 % 10;
            }
            if (10 - (sum % 10) == TZ[8] - '0')
                return true;
            return false;
        }
    }
}
