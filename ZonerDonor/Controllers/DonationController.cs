using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZonerDonor.Entities;
using ZonerDonor.Services;
using ZonerDonor.ViewModels;
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

        public async Task<IActionResult> Index(Guid? id)
        {
            DonationCreateViewModel vm = new DonationCreateViewModel();
            vm.Donation = new DonationDto();
            if (id.HasValue)
            {
                vm.Donation.FundraiserId = id.Value;
            }
            else
            {
                var results = await fundraiserService.GetFundraisersAsync();
                vm.Fundraisers = mapper.Map<IEnumerable<FundraiserDto>>(results)
                                        .Select(f => new SelectListItem { Text = f.Name, Value = f.Id.ToString() })
                                        .ToList();
            }
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DonationCreateViewModel vm)
        {
            if (vm == null)
            {
                throw new ArgumentNullException(nameof(vm));
            }
            vm.Donation.DonationDate = DateTimeOffset.Now;
            vm.Donation.DonorId = await GetDonorId();
            if (vm.Donation.FundraiserId == Guid.Empty)
            {
                vm.Donation.FundraiserId = vm.FundraiserId;
            }

            var donation = mapper.Map<Models.Donation>(vm.Donation);
            if (ModelState.IsValid)
            {
                donationService.AddDonation(donation);
                await donationService.SaveChangesAsync();
                return RedirectToAction("DonateComplete");
            }
            return View(vm);

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
