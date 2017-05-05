using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WZ.ApplicationService.Interfaces;
using WZ.UI.Mvc.ViewModels;

namespace WZ.UI.Mvc.Controllers
{
    public class QuickDonateController: Controller
    {
        protected readonly IQuickDonateService _quickDonateService;
        public QuickDonateController(IQuickDonateService quickDonateService)
        {
            this._quickDonateService = quickDonateService;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submit(ViewModels.QuickDonateViewModel viewModel)
        {
            if (ModelState.IsValid == true)
            {
                //process donation
                SubmitDonation(viewModel);
            }
            return View("Index", viewModel);
        }

        protected void SubmitDonation(QuickDonateViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
