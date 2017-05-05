using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZ.ApplicationService.DTO;
using WZ.Domain.Models;
using WZ.Services.Interfaces;

namespace WZ.ApplicationService
{
    public class QuickDonateService : Interfaces.IQuickDonateService
    {
        protected readonly IConfigurationService _configurationService;
        protected readonly IValidationService _validationService;
        protected readonly ISessionService _sessionService;
        protected readonly IUserService _userService;
        protected readonly IEmailService _emailService;
        protected readonly ICreditCardService _creditCardService;
        protected readonly ICartService _cartService;
        protected readonly ILoggingService _loggingService;

        public QuickDonateService(
            IConfigurationService configurationService,
            IValidationService validationService,
            ISessionService sessionService,
            IUserService userService,
            IEmailService emailService,
            ICreditCardService creditCardService,
            ICartService cartService,
            ILoggingService loggingService)
        {
            this._configurationService = configurationService;
            this._validationService = validationService;
            this._sessionService = sessionService;
            this._userService = userService;
            this._emailService = emailService;
            this._creditCardService = creditCardService;
            this._cartService = cartService;
            this._loggingService = loggingService;
        }

        #region Data Binding

        public IEnumerable<decimal> GetSuggestedAmounts()
        {
            return this._configurationService.GetList<decimal>("SuggestedAmounts", "10,20");
        }
        #endregion

        #region Data Submit

        public QuickDonateResponseDTO ProcessDonation(DTO.QuickDonateRequestDTO request)
        {
            var response = new QuickDonateResponseDTO();
            var sessionContext = _sessionService.GetNewSession();

            //validate fields 
            if (ValidateInputs(request, response) == false)
            {
                return response;
            }

            //login or register user
            if (LoginOrRegisterUser(request.Email, sessionContext, response) == false)
            {
                return response;
            }

            //add donation to cart
            if (AddContributionToCart(request, sessionContext, response) == false)
            {
                return response;
            }

            //process checkout with credit card payment
            if (ProcessCheckout(request, sessionContext, response) == false)
            {
                return response;
            }

            try
            {
                //send confirmation email
                SendConfirmationEmail(request, sessionContext);

                //run post checkout tasks
                PostCheckout(request, sessionContext);
            }
            catch (Exception ex)
            {
                this._loggingService.LogError(ex);
            }

            return response;
        }

        private bool ValidateInputs(QuickDonateRequestDTO request, QuickDonateResponseDTO response)
        {
            if (request.Amount <= 0)
            {
                response.Message = "Invalid Amount";
                return false;
            }

            if (_validationService.IsEmailAddress(request.Email) == false)
            {
                response.Message = "Invalid Email Address";
                return false;
            }

            if (_validationService.IsCreditCardNumber(request.CreditCardNumber) == false)
            {
                response.Message = "Invalid Credit Card Number";
                return false;
            }

            if (_validationService.IsValidExpirationDate(request.CreditCardMonth, request.CreditCardYear) == false)
            {
                response.Message = "Invalid Credit Card Expire Date";
                return false;
            }

            if (string.IsNullOrEmpty(request.CreditCardCVV))
            {
                response.Message = "Invalid Credit Card Security Code";
                return false;
            }

            return true;
        }

        private bool LoginOrRegisterUser(string email, Session sessionContext, QuickDonateResponseDTO response)
        {
            var user = _userService.FindUserByEmail(email);
            if (user == null)
            {
                //user does not exist
                var registered = _userService.Register(email);
                if (registered == false)
                {
                    response.Message = string.Format("Can not register user using email {0}", email);
                    return false;
                }
            }


            var loggedIn = _userService.Login(user, sessionContext);
            if (loggedIn == false)
            {
                response.Message = string.Format("Can not login user using email {0}", email);
                return false;
            }

            return true;
        }

        private bool AddContributionToCart(QuickDonateRequestDTO request, Session sessionContext, QuickDonateResponseDTO response)
        {
            var fundId = _configurationService.GetValue("QuickDonateFundId", 0);
            var onAccountId = _configurationService.GetValue("QuickDonateOnAccountId", 0);
            var success = _cartService.AddContribution(request.Amount, fundId, onAccountId, sessionContext);
            if (!success)
            {
                response.Message = "Can not add contribution to cart at this time, please try again later.";
                return false;
            }

            return true;
        }

        private bool ProcessCheckout(QuickDonateRequestDTO request, Session sessionContext, QuickDonateResponseDTO response)
        {
            var creditCard = new CreditCard()
            {
                CardNumber = request.CreditCardNumber,
                ExpireMonth = request.CreditCardMonth,
                ExpireYear = request.CreditCardYear,
                SecurityCode = request.CreditCardCVV
            };
            var success = _cartService.Checkout(creditCard, sessionContext);
            if (success == false)
            {
                response.Message = "Error Checkout the Cart";
                return false;
            }

            return true;
        }

        private void SendConfirmationEmail(QuickDonateRequestDTO request, Session sessionContext)
        {
            var user = _userService.GetLoggedInUser(sessionContext);
            var cart = _cartService.GetCart(sessionContext);
            var creditCard = new CreditCard()
            {
                CardNumber = request.CreditCardNumber,
                ExpireMonth = request.CreditCardMonth,
                ExpireYear = request.CreditCardYear,
                SecurityCode = request.CreditCardCVV
            };

            var subject = "Confirmation";
            var content = GetConfirmationEmail(user, cart, creditCard);
            var fromAddress = "ticket@aaa.com";
            var toAddress = request.Email;
            var ccAddress = string.Empty;
            var bccAddress = string.Empty;

            _emailService.SendEmail(subject, content, fromAddress, toAddress, ccAddress, bccAddress);
        }

        private string GetConfirmationEmail(User user, Cart cart, CreditCard creditCard)
        {
            throw new NotImplementedException();
        }

        private void PostCheckout(QuickDonateRequestDTO request, Session sessionContext)
        {
            //nothing in post checkout
        }

        #endregion
    }
}
