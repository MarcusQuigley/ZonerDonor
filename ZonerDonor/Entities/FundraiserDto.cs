using System;
using System.ComponentModel.DataAnnotations;

namespace ZonerDonor.Entities
{
    public class FundraiserDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public decimal CurrentTotal { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public int PercentComplete => Convert.ToInt32((CurrentTotal / Amount) * 100);
        }
}
