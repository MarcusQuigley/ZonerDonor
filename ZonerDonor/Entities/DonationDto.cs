using System;
using System.ComponentModel.DataAnnotations;

namespace ZonerDonor.Entities
{
    public class DonationDto
    {
        public Guid Id { get; set; }
        public Guid FundraiserId { get; set; }
        public Guid DonorId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTimeOffset DonationDate { get; set; }
        public DonorDto Donor { get; set; }

        public string WhenDonated {
            get {
                var today = DateTimeOffset.Now;
                var daysAgo =(int) today.Subtract(DonationDate).TotalDays;
                if (daysAgo < 1)
                    return "today";
                if (daysAgo < 31)
                    return $"{daysAgo} days ago";
                return $"{(int)daysAgo / 30} month ago";
            }
        }
                
    }
}
