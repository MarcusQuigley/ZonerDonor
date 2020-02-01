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
    public class DonateController : Controller
    {
        readonly IDonationRepository donationService;
        readonly IMapper mapper;
        public DonateController(IDonationRepository donationService, IMapper mapper)
        {
            this.donationService = donationService ?? throw new ArgumentNullException(nameof(donationService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [BindProperty]
        public DonationDto  Donation { get; set; }

        public IActionResult Donate(Guid id)
        {
            Donation = new DonationDto()
            {
                FundraiserId = id
            };
            
            return View(Donation);
        }

        [HttpPost]
        public async Task<IActionResult> Donate()//DonationDto donationDto)
        {
            if (Donation == null)
            {
                throw new ArgumentNullException(nameof(Donation));
            }
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

    }
}
