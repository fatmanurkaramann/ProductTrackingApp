using Business.DTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        int CreateUser(UserDto userDto);
        List<User> GetAll();
        void Login(UserDto userDto);
    }
}
