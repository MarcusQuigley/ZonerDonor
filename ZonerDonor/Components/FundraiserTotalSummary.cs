using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZonerDonor.Entities;
using ZonerDonor.Services;
using ZonerDonor.ViewModels;

namespace ZonerDonor.Components
{
    public class FundraiserTotalSummary :  ViewComponent
    {
        readonly IDonationRepository donationService;
        readonly IMapper mapper;
        public FundraiserTotalSummary(IDonationRepository donationService, 
            IMapper mapper)
        {
            this.donationService = donationService ?? throw new ArgumentNullException(nameof(donationService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IViewComponentResult> InvokeAsync(FundraiserDto fundraiser)
        {
            var donations = await donationService.GetDonationsByFundAsync(fundraiser.Id);
            if (donations == null)
            {
                throw new ArgumentNullException(nameof(donations));
            }
            var vm = new FundTotalSummaryViewModel
            {
                Fundraiser = fundraiser,
                Donations = mapper.Map<IEnumerable<DonationDto>>(donations)
            };
            return View(vm);


        }
    }
}
