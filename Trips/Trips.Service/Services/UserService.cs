using AutoMapper;
using Trips.Core.DTOs;
using Trips.Core.Entities;
using Trips.Core.IRepositories;
using Trips.Core.IRepository;
using Trips.Core.IService;

namespace Trips.Service.Servise
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _iManager;
        private readonly IMapper _mapper;
        public UserService(IRepositoryManager iManager,IMapper mapper)
        {
            _iManager = iManager;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> GetAsync()
        {
            List<User> users = await _iManager.IUserRep.GetAsync();
            List<UserDto> userDtos = _mapper.Map<List<UserDto>>(users);
            return userDtos;
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _iManager.IUserRep.GetAllAsync();
        }
        public async Task<UserDto>? GetByIdAsync(int id)
        {
            User user =await _iManager.IUserRep.GetByIdAsync(id);
            UserDto userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<UserDto> AddAsync(UserDto userDto)
        {
            if (!CorrectTZ(userDto.TZ))
                return null;
            User user = _mapper.Map<User>(userDto);
            user=await _iManager.IUserRep.AddAsync(user);
            if (user != null)
               await _iManager.SaveAsync();
            userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
        public async Task<UserDto> UpdateAsync(int id, UserDto userDto)
        {
            if (!CorrectTZ(userDto.TZ))
                return null;
            User user = _mapper.Map<User>(userDto);
            user =await _iManager.IUserRep.UpdateAsync(id, user);
            if (user != null)
               await _iManager.SaveAsync();
            userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            bool flag =await _iManager.IUserRep.DeleteAsync(id);
            if(flag)
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