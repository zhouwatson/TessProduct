using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZ.Services.Interfaces
{
    public interface IValidationService
    {
        string GetCardTypeString(string cardNumber);

        bool IsCreditCardNumber(string creditCardNumber);

        bool IsValidExpirationDate(string monthString, string yearString);

        bool IsValidExpirationDate(int month, int year);

        bool IsEmailAddress(string emailAddress);
    }
}
