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
        public List<UserDto> Get()
        {
            List<User> users = _iManager.IUserRep.Get();
            List<UserDto> userDtos = _mapper.Map<List<UserDto>>(users);
            return userDtos;
        }
        public List<User> GetAll()
        {
            return _iManager.IUserRep.GetAll();
        }
        public UserDto? GetById(int id)
        {
            User user = _iManager.IUserRep.GetById(id);
            UserDto userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public UserDto Add(UserDto userDto)
        {
            if (!CorrectTZ(userDto.TZ))
                return null;
            User user = _mapper.Map<User>(userDto);
            user= _iManager.IUserRep.Add(user);
            if (user != null)
                _iManager.Save();
            userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
        public UserDto Update(int id, UserDto userDto)
        {
            if (!CorrectTZ(userDto.TZ))
                return null;
            User user = _mapper.Map<User>(userDto);
            user = _iManager.IUserRep.Update(id, user);
            if (user != null)
                _iManager.Save();
            userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
        public bool Delete(int id)
        {
            bool flag = _iManager.IUserRep.Delete(id);
            if(flag)
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