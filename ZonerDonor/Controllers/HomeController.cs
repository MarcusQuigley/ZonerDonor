using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZonerDonor.Entities;
using ZonerDonor.Services;

namespace ZonerDonor.Controllers
{
    public class HomeController : Controller
    {
        readonly IFundraiserRepository fundraiserService;
        readonly IMapper mapper;
        public HomeController(IFundraiserRepository fundraiserService, IMapper mapper)
        {
            this.fundraiserService = fundraiserService ?? throw new ArgumentNullException(nameof(fundraiserService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        } 
        public async Task<IActionResult> Index()
        {
            var funds = await fundraiserService.GetLatestFundraisersAsync();
            return View(mapper.Map<IEnumerable<FundraiserDto>>(funds));
        }
    }
}
