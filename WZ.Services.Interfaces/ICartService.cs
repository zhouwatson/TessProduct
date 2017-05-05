using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZ.Domain.Models;

namespace WZ.Services.Interfaces
{
    public interface ICartService
    {
        bool AddContribution(decimal amount, int fundId, int onAccountId, Session sessionContext);
        bool Checkout(CreditCard creditCard, Session sessionContext);
        Cart GetCart(Session sessionContext);
    }
}
