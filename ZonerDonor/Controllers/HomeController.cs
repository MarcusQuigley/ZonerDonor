using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZonerDonor.Services;

namespace ZonerDonor.Controllers
{
    public class HomeController : Controller
    {
        readonly IFundraiserRepository fundraiserService;
        public HomeController(IFundraiserRepository fundraiserService)
        {
            this.fundraiserService = fundraiserService ?? throw new ArgumentNullException(nameof(fundraiserService));
        } 
        public async Task<IActionResult> Index()
        {
            var funds = await fundraiserService.GetLatestFundraisersAsync();
            return View(funds);
        }
    }
}
