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
        public async Task<List<GuideDto>> GetAsync()
        {
            List<Guide> guides = await _iManager.IGuideRep.GetAsync();
            List<GuideDto> guideDtos = _mapper.Map<List<GuideDto>>(guides);
            return guideDtos;
        }
        public async Task<List<Guide>> GetAllAsync()
        {
            return await _iManager.IGuideRep.GetAllAsync();
        }
        public async Task<GuideDto>? GetByIdAsync(int id)
        {
            Guide guide =await _iManager.IGuideRep.GetByIdAsync(id);
            GuideDto guideDto = _mapper.Map<GuideDto>(guide);
            return guideDto;
        }

        public async Task<GuideDto> AddAsync(GuideDto guideDto)
        {
            if (!CorrectTZ(guideDto.TZ))
                return null;
            Guide guide = _mapper.Map<Guide>(guideDto);
            guide=await _iManager.IGuideRep.AddAsync(guide);
            if (guide != null)
               await _iManager.SaveAsync();
            guideDto = _mapper.Map<GuideDto>(guide);
            return guideDto;
        }
        public async Task<GuideDto> UpdateAsync(int id, GuideDto guideDto)
        {
            if (!CorrectTZ(guideDto.TZ))
                return null;
            Guide guide = _mapper.Map<Guide>(guideDto);
            guide =await _iManager.IGuideRep.UpdateAsync(id, guide);
            if (guide != null)
               await _iManager.SaveAsync();
            guideDto = _mapper.Map<GuideDto>(guide);
            return guideDto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            bool flag=await _iManager.IGuideRep.DeleteAsync(id);
            if (flag)
             await _iManager.SaveAsync();
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
