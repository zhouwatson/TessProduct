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
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            this._cartRepository = cartRepository;
        }

        public bool AddContribution(decimal amount, int fundId, int onAccountId, Session sessionContext)
        {
            return this._cartRepository.AddContribution(amount, fundId, onAccountId, sessionContext);
        }

        public bool Checkout(CreditCard creditCard, Session sessionContext)
        {
            return this._cartRepository.Checkout(creditCard, sessionContext);
        }

        public Cart GetCart(Session sessionContext)
        {
            return this._cartRepository.GetCart(sessionContext);
        }
    }
}
