using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZ.Domain.Models;
using WZ.Repository.Interfaces;

namespace WZ.Infrastructure.Tessitura.Repository
{
    public class CartRepository : ICartRepository
    {
        public bool AddContribution(decimal amount, int fundId, int onAccountId, Session sessionContext)
        {
            throw new NotImplementedException();
        }

        public bool Checkout(CreditCard creditCard, Session sessionContext)
        {
            throw new NotImplementedException();
        }

        public Cart GetCart(Session sessionContext)
        {
            throw new NotImplementedException();
        }
    }
}
