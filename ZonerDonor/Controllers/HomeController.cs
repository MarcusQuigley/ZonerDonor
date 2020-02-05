using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZonerDonor.Entities;
using ZonerDonor.Services;

namespace ZonerDonor.Controllers
{
    public class HomeController : BaseController
    {
        readonly IFundraiserRepository fundraiserService;
        readonly IDonorRepository donorService;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, IFundraiserRepository fundraiserService, IDonorRepository donorService) :
            base(logger, mapper)
        {
            this.donorService = donorService ?? throw new ArgumentNullException(nameof(donorService));
            this.fundraiserService = fundraiserService ?? throw new ArgumentNullException(nameof(fundraiserService));
        }

        public async Task<IActionResult> Index()
        {
            var funds = await fundraiserService.GetLatestFundraisersAsync();
            return View(Mapper.Map<IEnumerable<FundraiserDto>>(funds));
        }
    }
}
