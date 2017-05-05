using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZ.Repository.Interfaces;
using WZ.Services.Interfaces;

namespace WZ.Services
{
    public class CreditCardServices: ICreditCardService
    {
        private readonly ICreditCardRepository _creditCardRepository;

        public CreditCardServices(ICreditCardRepository creditCardRepository)
        {
            this._creditCardRepository = creditCardRepository;
        }
    }
}
