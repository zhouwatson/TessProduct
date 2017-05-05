using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZ.Domain.Models;
using WZ.Repository.Interfaces;
using WZ.Services.Interfaces;

namespace WZ.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public User FindUserByEmail(string email)
        {
            return this._userRepository.FindUserByEmail(email);
        }

        public User GetLoggedInUser(Session sessionContext)
        {
            return this._userRepository.GetLoggedInUser(sessionContext);
        }

        public bool Login(User user, Session sessionContext)
        {
            return this._userRepository.Login(user,sessionContext);
        }

        public bool Register(string email)
        {
            return this._userRepository.Register(email);
        }
    }
}
