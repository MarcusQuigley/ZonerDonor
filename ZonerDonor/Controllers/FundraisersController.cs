using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZonerDonor.Entities;
using ZonerDonor.Services;

namespace ZonerDonor.Controllers
{
    public class FundraisersController : Controller
    {
        readonly IFundraiserRepository fundraiserService;
        readonly IMapper mapper;
        public FundraisersController(IFundraiserRepository fundraiserService, IMapper mapper)
        {
            this.fundraiserService = fundraiserService ?? throw new ArgumentNullException(nameof(fundraiserService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IActionResult> List()
        {
            var results = await fundraiserService.GetFundraisersAsync();
            return View(mapper.Map<IEnumerable<FundraiserDto>>(results));
        }
    }
}