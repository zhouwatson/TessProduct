using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZ.Domain.Models;

namespace WZ.Repository.Interfaces
{
    public interface ISessionRepository
    {
        Session GetNewSession();
    }
}
