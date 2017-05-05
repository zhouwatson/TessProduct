using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZ.Domain.Models;

namespace WZ.Repository.Interfaces
{
    public interface IUserRepository
    {
        bool Register(string email);

        User FindUserByEmail(string email);

        User GetLoggedInUser(Session sessionContext);

        bool Login(User user, Session sessionContext);
    }
}
