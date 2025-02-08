using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trips.Core.IRepositories
{
    public interface IRepositoryManager
    {
        IAttractionRepository IAttractionRep { get; set; }
        IGuideRepository IGuideRep { get; set; }
        IOrderRepository IOrderRep { get; set; }
        ITripRepository ITripRep { get; set; }
        IUserRepository IUserRep { get; set; }
        Task SaveAsync();
    }
}
