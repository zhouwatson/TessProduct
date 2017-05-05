using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZ.UI.Mvc.ViewModels
{
    public interface IQuickDonateViewModel
    {
        decimal Amount { get; set; }

        string Email { get; set; }

        string CreditCardNumber { get; set; }

        int CreditCardMonth { get; set; }

        int CreditCardYear { get; set; }
    }
}
