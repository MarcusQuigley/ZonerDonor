using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZonerDonor.Entities;
using ZonerDonor.Services;
using Models = ZonerDonor.Core.Models;
namespace ZonerDonor.Controllers
{
    public class DonationController : Controller
    {
        readonly IDonationRepository donationService;
        readonly IFundraiserRepository fundraiserService;
        readonly IDonorRepository donorService;
        readonly IMapper mapper;
        public DonationController(IDonationRepository donationService, IFundraiserRepository fundraiserService, 
                                IDonorRepository donorService, IMapper mapper)
        {
            this.donationService = donationService ?? throw new ArgumentNullException(nameof(donationService));
            this.fundraiserService = fundraiserService ?? throw new ArgumentNullException(nameof(fundraiserService));
            this.donorService = donorService ?? throw new ArgumentNullException(nameof(donorService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [BindProperty]
        public DonationDto  Donation { get; set; }

        public IEnumerable<FundraiserDto> Fundraisers { get; set; }

        public async Task<IActionResult> Index(Guid id)
        {
            Donation = new DonationDto();
            if (id != Guid.Empty)
            {
                Donation.FundraiserId = id;
            }
            else
            {
                var results = await fundraiserService.GetFundraisersAsync();
                Fundraisers = mapper.Map<IEnumerable<FundraiserDto>>(results);
            }
            return View(Donation);
        }

        [HttpPost]
        public async Task<IActionResult> Create()//DonationDto donationDto)
        {
            if (Donation == null)
            {
                throw new ArgumentNullException(nameof(Donation));
            }
            Donation.DonationDate = DateTimeOffset.Now;
            Donation.DonorId = await GetDonorId();

            var donation = mapper.Map<Models.Donation>(Donation);
            if (ModelState.IsValid)
            {
                donationService.AddDonation(donation);
                await donationService.SaveChangesAsync();
                return RedirectToAction("DonateComplete");
            }
            return View(Donation);
             
        }
        public IActionResult DonateComplete()
        {
            ViewBag.Confirmation = "Bingo!";
            return View();
        }

        private async Task<Guid> GetDonorId()
        {
            var donors = await donorService.GetDonorsAsync();
            if (!donors.Any())
            {
                throw new InvalidOperationException("No donors exist");
            }
            return donors.FirstOrDefault().Id;
        }

    }
}
