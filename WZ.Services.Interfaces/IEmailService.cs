using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZ.Domain.Models;

namespace WZ.Services.Interfaces
{
    public interface IEmailService
    {
        bool SendEmail(
           string subject,
           string body,
           string from,
           string to,
           string cc,
           string bcc);

    }
}
