using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using ZonerDonor.Entities;
using ZonerDonor.Hubs;
using ZonerDonor.Services;
using Models = ZonerDonor.Core.Models;

namespace ZonerDonor.Controllers
{
    public class FundraiserController : Controller
    {
        readonly IFundraiserRepository fundraiserService;
        readonly IMapper mapper;
        readonly IHubContext<ZonorHub> signalHub;

        public FundraiserController(IFundraiserRepository fundraiserService, 
                            IMapper mapper,
                            IHubContext<ZonorHub> signalHub)
        {
            this.fundraiserService = fundraiserService ?? throw new ArgumentNullException(nameof(fundraiserService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.signalHub = signalHub ?? throw new ArgumentNullException(nameof(signalHub));
        }
   
        [BindProperty]
        public FundraiserDto Fundraiser { get; set; }

        public async Task<IActionResult> Detail(Guid id)
        {
            var fundraiser = await fundraiserService.GetFundraiserAsync(id);
            if (fundraiser == null)
            {
                return NotFound();
            }
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
                    await signalHub.Clients.All.SendAsync("NewFundraiser", mapper.Map<FundraiserDto>(fundraiser));

                    return RedirectToAction("List", "Fundraisers");
                }
             }
            return View(Fundraiser);
        }
    }
}