using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZ.Services.Interfaces;

namespace WZ.ApplicationService
{
    public class BecomeAMemberService : QuickDonateService, Interfaces.IBecomeAMemberService
    {
        public BecomeAMemberService(IConfigurationService configurationService, IValidationService validationService, ISessionService sessionService, IUserService userService, IEmailService emailService, ICreditCardService creditCardService, ICartService cartService, ILoggingService loggingService) : base(configurationService, validationService, sessionService, userService, emailService, creditCardService, cartService, loggingService)
        {
        }
    }
}
