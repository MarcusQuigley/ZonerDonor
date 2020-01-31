using System;

namespace ZonerDonor.Core.Models
{
    public class Donation
    {
        public Guid FundraiserId { get; set; }
        public Guid DonorId { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset DonationDate { get; set; }
    }
}
