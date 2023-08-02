using Business.Abstract;
using Business.DTOs;
using DataAccess.Repositories.Abstraction;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int CreateUser(UserDto userDto)
        {
            User user = new() 
            { 
              Name = userDto.Name,
              Surname = userDto.Surname,
              Email = userDto.Email,
              Password=userDto.Password
            };
            return _userRepository.Add(user);
        }
        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        public void Login(UserDto userDto)
        {

            foreach (var item in _userRepository.GetAll())
            {
                if (userDto.Email == item.Email && userDto.Password == item.Password)
                {
                    Console.WriteLine("Giriş yapıldı!");
                }
            }
        }
    }
}
