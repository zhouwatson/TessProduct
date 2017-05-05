using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZ.Domain.Models;
using WZ.Repository.Interfaces;

namespace WZ.Infrastructure.Tessitura.Repository
{
    public class SessionRepository : ISessionRepository
    {
        TessituraSoapApi _tessituraSoapApi;
        public SessionRepository()
        {
            _tessituraSoapApi = new Tessitura.TessituraSoapApi();
        }

        public Session GetNewSession()
        {
            return new Session()
            {
                SessionKey = _tessituraSoapApi.GetNewSessionKey(string.Empty)
            };
        }
    }
}
