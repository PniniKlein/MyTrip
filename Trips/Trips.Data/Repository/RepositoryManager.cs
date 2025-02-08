using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trips.Core.IRepositories;

namespace Trips.Data.Repository
{
    public class RepositoryManager: IRepositoryManager
    {
        DataContext _dataContext;
        public IAttractionRepository IAttractionRep { get; set; }
        public IGuideRepository IGuideRep { get; set; }
        public IOrderRepository IOrderRep { get; set; }
        public ITripRepository ITripRep { get; set; }
        public IUserRepository IUserRep { get; set; }

        public RepositoryManager(DataContext dataContext, IAttractionRepository attractionRepository, IGuideRepository guideRepository,
                                 IOrderRepository orderRepository,ITripRepository tripRepository,IUserRepository userRepository)
        {
            _dataContext = dataContext;
            IAttractionRep = attractionRepository;
            IGuideRep = guideRepository;
            IOrderRep = orderRepository;
            ITripRep = tripRepository;
            IUserRep = userRepository;
        }
        public async Task SaveAsync()
        {
           await _dataContext.SaveChangesAsync();
        }
    }
}
