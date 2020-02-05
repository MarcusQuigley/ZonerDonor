using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZonerDonor.Entities;
using ZonerDonor.Services;
using Models = ZonerDonor.Core.Models;

namespace ZonerDonor.Controllers
{
    public class DonorController : Controller
    {
        readonly IDonorRepository donorService;
        readonly IMapper mapper;
        readonly ILogger<DonorController> logger;


        public DonorController(IDonorRepository donorService, IMapper mapper, ILogger<DonorController> logger)
        {
            this.donorService = donorService ?? throw new ArgumentNullException(nameof(donorService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(DonorDto donorDto)
        {
            if (donorDto == null)
            {
                throw new ArgumentNullException(nameof(donorDto));
            }
            if (ModelState.IsValid)
            {
                donorService.AddDonor(mapper.Map<Models.Donor>(donorDto));
                await donorService.SaveChangesAsync();
                return RedirectToAction("DonorComplete");
            }
            return View(donorDto);
        }

        public IActionResult DonorComplete()
        {
            ViewBag.Confirmation = "Donor created!";
            return View();
        }
    }
}
