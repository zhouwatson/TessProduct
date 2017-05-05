using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZ.Domain.Models;
using WZ.Repository.Interfaces;

namespace WZ.Infrastructure.Tessitura.Repository
{
    public class UserRepository : IUserRepository
    {
        public User FindUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetLoggedInUser(Session sessionContext)
        {
            throw new NotImplementedException();
        }

        public bool Login(User user, Session sessionContext)
        {
            throw new NotImplementedException();
        }

        public bool Register(string email)
        {
            throw new NotImplementedException();
        }
    }
}
