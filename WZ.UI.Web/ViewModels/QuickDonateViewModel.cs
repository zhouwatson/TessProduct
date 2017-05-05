using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WZ.UI.Mvc.ViewModels
{
    public class QuickDonateViewModel : IQuickDonateViewModel
    {
        [Required(ErrorMessage = "Donation Amount is Required")]
        [Range(0.1d, Double.MaxValue, ErrorMessage = "Donation Amount is invalid")]
        public virtual decimal Amount { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is invalid")]
        public virtual string Email { get; set; }

        [DisplayName("Credit Card Number")]
        [Required(ErrorMessage = "Credit Card Number is Required")]
        [MaxLength(16, ErrorMessage = "Credit Card Number is invalid")]
        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$", ErrorMessage = "Credit Card Number is invalid")]
        public virtual string CreditCardNumber { get; set; }

        [DisplayName("Expire Month")]
        [Required(ErrorMessage = "Credit Card Expire Month is Required")]
        [Range(1, 12, ErrorMessage = "Credit Card Expire Month is invalid")]
        public virtual int CreditCardMonth { get; set; }

        [DisplayName("Expire Year")]
        [Required(ErrorMessage = "Credit Card Expire Year is Required")]
        [Range(2016, 9999, ErrorMessage = "Credit Card Expire Year is invalid")]
        public virtual int CreditCardYear { get; set; }
    }
}
