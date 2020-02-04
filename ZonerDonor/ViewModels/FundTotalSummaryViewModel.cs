using System.Collections.Generic;
using ZonerDonor.Entities;

namespace ZonerDonor.ViewModels
{
    public class FundTotalSummaryViewModel
    {
        public FundraiserDto Fundraiser { get; set; }
        public IEnumerable<DonationDto> Donations { get; set; }
    }
}
