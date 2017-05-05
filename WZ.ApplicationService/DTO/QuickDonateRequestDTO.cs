using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZ.ApplicationService.DTO
{
    public class QuickDonateRequestDTO
    {
        public virtual decimal Amount { get; set; }

        public virtual string Email { get; set; }

        public virtual string CreditCardNumber { get; set; }

        public virtual int CreditCardMonth { get; set; }

        public virtual int CreditCardYear { get; set; }

        public virtual string CreditCardCVV { get; set; }
    }
}
