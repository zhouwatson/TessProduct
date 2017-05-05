using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZ.Services.Interfaces;

namespace WZ.Infrastructure.Common.Validation
{
    public class ValidationService : IValidationService
    {
        protected enum CreditCardType
        {
            Undefined,
            AmericanExpress,
            DinersClub,
            CarteBlanche,
            Discover,
            EnRoute,
            Jcb,
            MasterCard,
            Visa
        }
        protected virtual CreditCardType GetCardType(string cardNumber)
        {
            CreditCardType undefined = CreditCardType.Undefined;
            cardNumber = System.Text.RegularExpressions.Regex.Replace(cardNumber, @"\D", string.Empty);
            if (((cardNumber.Length >= 10) && (cardNumber.Length <= 0x13)) &&
                IsCreditCardNumber(cardNumber))
            {
                switch (Convert.ToInt32(cardNumber.Substring(0, 2)))
                {
                    case 0x22:
                    case 0x25:
                        return CreditCardType.AmericanExpress;

                    case 0x24:
                        return CreditCardType.DinersClub;

                    case 0x26:
                        return CreditCardType.CarteBlanche;

                    case 0x33:
                    case 0x34:
                    case 0x35:
                    case 0x36:
                    case 0x37:
                        return CreditCardType.MasterCard;
                }
                int num2 = Convert.ToInt32(cardNumber.Substring(0, 4));
                if ((num2 == 0x7de) || (num2 == 0x865))
                {
                    undefined = CreditCardType.EnRoute;
                }
                else
                {
                    if ((num2 == 0x853) || (num2 == 0x708))
                    {
                        return CreditCardType.Jcb;
                    }
                    if (num2 == 0x177b)
                    {
                        undefined = CreditCardType.Discover;
                    }
                    else
                    {
                        switch (Convert.ToInt32(cardNumber.Substring(0, 3)))
                        {
                            case 300:
                            case 0x12d:
                            case 0x12e:
                            case 0x12f:
                            case 0x130:
                            case 0x131:
                                return CreditCardType.DinersClub;
                        }
                        switch (Convert.ToInt32(cardNumber.Substring(0, 1)))
                        {
                            case 3:
                                return CreditCardType.Jcb;

                            case 4:
                                return CreditCardType.Visa;
                        }
                    }
                }
            }
            return undefined;
        }

        public string GetCardTypeString(string cardNumber)
        {
            CreditCardType cardType = GetCardType(cardNumber);
            switch (((int)cardType))
            {
                case 0:
                    return "Unknown";

                case 1:
                    return "American Express";

                case 2:
                    return "Diners Club";

                case 3:
                    return "Carte Blanche";

                case 4:
                    return "Discover";

                case 5:
                    return "En Route";

                case 6:
                    return "JCB";

                case 7:
                    return "MasterCard";

                case 8:
                    return "Visa";
            }
            throw new NotImplementedException("This card type doesn't have a string representation: " +
                                              Convert.ToString((int)cardType));
        }

        public bool IsCreditCardNumber(string creditCardNumber)
        {
            byte num;
            var builder = new System.Text.StringBuilder();
            short num2 = 0;
            if (creditCardNumber == null)
            {
                return false;
            }
            var str = System.Text.RegularExpressions.Regex.Replace(creditCardNumber, "([^0-9]+)", string.Empty);
            if ((str.Length < 13) || (str.Length > 0x13))
            {
                return false;
            }
            int num3 = str.Length - 1;
            Label_00AA:
            const int num6 = 0;
            if (num3 >= num6)
            {
                if ((((str.Length - num3) + 1) % 2) == 1)
                {
                    num = byte.Parse(Convert.ToString(str[num3]));
                    builder.Append(2 * num);
                }
                else
                {
                    builder.Append(str[num3]);
                }
                num3 += -1;
                goto Label_00AA;
            }
            var num5 = builder.Length - 1;
            for (var i = 0; i <= num5; i++)
            {
                num = byte.Parse(Convert.ToString(builder[i]));
                num2 = (short)(num2 + num);
            }
            return ((num2 % 10) == 0);
        }

        public bool IsValidExpirationDate(string monthString, string yearString)
        {
            int year = 0;
            int month = 0;

            if (!int.TryParse(yearString, out year) || !int.TryParse(monthString, out month))
                return false;

            if (new DateTime(year, month, 1) <= DateTime.Now)
                return false;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool IsValidExpirationDate(int month, int year)
        {
            if (new DateTime(year, month, 1) <= DateTime.Now)
                return false;

            return true;
        }


        public bool IsEmailAddress(string emailAddress)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(emailAddress, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }
    }
}
