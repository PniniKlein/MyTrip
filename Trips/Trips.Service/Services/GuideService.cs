using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.Entities;
using Trips.Core.IRepositories;
using Trips.Core.IRepository;
using Trips.Core.IService;

namespace Trips.Service.Servises
{
    public class GuideService : IGuideService
    {
        readonly IRepositoryManager _iManager;
        public GuideService(IRepositoryManager iManager)
        {
            _iManager = iManager;
        }
        public List<Guide> Get()
        {
            return _iManager.IGuideRep.Get();
        }
        public List<Guide> GetAll()
        {
            return _iManager.IGuideRep.GetAll();
        }
        public Guide? GetById(int id)
        {
            return _iManager.IGuideRep.GetById(id);
        }

        public Guide Add(Guide guide)
        {
            if (!CorrectTZ(guide.TZ))
                return null;
            guide= _iManager.IGuideRep.Add(guide);
            if (guide != null)
                _iManager.Save();
            return guide;
        }
        public Guide Update(int id, Guide guide)
        {
            if (!CorrectTZ(guide.TZ))
                return null;
            guide = _iManager.IGuideRep.Update(id, guide);
            if (guide != null)
                _iManager.Save();
            return guide;
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
