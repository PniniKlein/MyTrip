using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepository;
using Trips.Core.IService;

namespace Trips.Service.Servises
{
    public class GuideService : IGuideService
    {
        readonly IRepository<Guide> _iRepository;
        public GuideService(IRepository<Guide> iRepository)
        {
            _iRepository = iRepository;
        }
        public List<Guide> Get()
        {
            return _iRepository.Get();
        }
        public Guide? GetById(int id)
        {
            return _iRepository.GetById(id);
        }

        public Guide Add(Guide guide)
        {
            if (!CorrectTZ(guide.TZ))
                return null;
            _iRepository.Add(guide);
            return guide;
        }
        public Guide Update(int id, Guide guide)
        {
            if (!CorrectTZ(guide.TZ))
                return null;
            _iRepository.Update(id, guide);
            return guide;
        }
        public bool Delete(int id)
        {
            return _iRepository.Delete(id);
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
