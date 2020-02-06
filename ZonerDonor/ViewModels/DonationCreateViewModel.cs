using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using ZonerDonor.Entities;

namespace ZonerDonor.ViewModels
{
    public class DonationCreateViewModel
    {
        public DonationDto Donation { get; set; }
        public IList<SelectListItem> Fundraisers { get; set; }
        public Guid FundraiserId { get; set; }
        public FundraiserDto Fundraiser { get; set; }
    }
}
