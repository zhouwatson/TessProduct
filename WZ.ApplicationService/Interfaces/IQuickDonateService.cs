using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZ.ApplicationService.Interfaces
{
    public interface IQuickDonateService
    {
        IEnumerable<decimal> GetSuggestedAmounts();

        DTO.QuickDonateResponseDTO ProcessDonation(DTO.QuickDonateRequestDTO quickDonateContent);
    }
}
