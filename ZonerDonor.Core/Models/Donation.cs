using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZonerDonor.Core.Models
{
    public class Donation
    {
        public Guid FundraiserId { get; set; }
        public Guid DonorId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        public DateTimeOffset DonationDate { get; set; }
    }
}
