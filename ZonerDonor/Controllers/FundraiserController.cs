using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZonerDonor.Entities;
using ZonerDonor.Services;
using Models = ZonerDonor.Core.Models;

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
   
        [BindProperty]
        public FundraiserDto Fundraiser { get; set; }

        public async Task<IActionResult> Detail(Guid id)
        {
            var fundraiser = await fundraiserService.GetFundraiserAsync(id);
            return View(mapper.Map<FundraiserDto>(fundraiser));

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            if (Fundraiser != null)
            {
                Fundraiser.CreatedDate = DateTimeOffset.Now;
                if (ModelState.IsValid)
                {
                    var fundraiser = mapper.Map<Models.Fundraiser>(Fundraiser);
                    fundraiserService.AddFundRaiser(fundraiser);
                    await fundraiserService.SaveChangesAsync();
                    return RedirectToAction("List", "Fundraisers");
                }
             }
            return View(Fundraiser);
        }

       

        //[HttpPost]
        //public IActionResult Create()
        //{


        //    return View();
        //}
    }
}