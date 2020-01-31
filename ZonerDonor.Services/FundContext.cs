using Microsoft.EntityFrameworkCore;
using ZonerDonor.Core.Models;

namespace ZonerDonor.Services
{
    public class FundContext : DbContext
    {
        public FundContext(DbContextOptions<FundContext> options)
            : base(options)
        { }

        public DbSet<Fundraiser> Fundraisers { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
    }
}
