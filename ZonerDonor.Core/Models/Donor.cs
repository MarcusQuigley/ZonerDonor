using System;

namespace ZonerDonor.Core.Models
{
    public class Donor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
