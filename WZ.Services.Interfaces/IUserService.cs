using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZ.Domain.Models;

namespace WZ.Services.Interfaces
{
    public interface IUserService
    {
        WZ.Domain.Models.User GetLoggedInUser(Session sessionContext);

        bool Login(WZ.Domain.Models.User user, Session sessionContext);

        bool Register(string email);

        WZ.Domain.Models.User FindUserByEmail(string email);

    }
}
