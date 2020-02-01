using System;
using System.ComponentModel.DataAnnotations;

namespace ZonerDonor.Entities
{
    public class DonationDto
    {
        public Guid FundraiserId { get; set; }
        public Guid DonorId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTimeOffset DonationDate { get; set; }
    }
}
