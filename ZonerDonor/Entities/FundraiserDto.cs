using System;

namespace ZonerDonor.Entities
{
    public class FundraiserDto
    {
       // public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentTotal { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
