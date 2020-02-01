using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZonerDonor.Entities;
using ZonerDonor.Services;

namespace ZonerDonor.Controllers
{
    public class FundraiserController : Controller
    {
        readonly IFundraiserRepository fundraiserService;
        readonly IMapper mapper;
        public FundraiserController(IFundraiserRepository fundraiserService, IMapper mapper)
        {
            this.fundraiserService = fundraiserService ?? throw new ArgumentNullException(nameof(fundraiserService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IActionResult> Index(Guid id)
        {
             var fundraiser = await fundraiserService.GetFundraiserAsync(id);
            return View(mapper.Map<FundraiserDto>(fundraiser));
           
        }
    }
}
