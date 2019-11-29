using Giselle.BAL.Services.Abstract;
using Giselle.DAL.Models;
using Giselle.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Giselle.BAL.Services
{
    public class UserService : IBaseService, IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> Get(int? UserID)
        {
            return _userRepository.Get(UserID);
        }
    }
}
