using Microsoft.EntityFrameworkCore;
using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Donation>()
            //    .HasKey(c => new { c.FundraiserId, c.DonorId });

            var donorId = Guid.NewGuid();
            var fundId = Guid.NewGuid();

            modelBuilder.Entity<Donor>().HasData(new Donor
            {
                Id = donorId,
                Name = "Marcus",
                CreatedDate = DateTimeOffset.Now.AddDays(-30)
            });

             modelBuilder.Entity<Fundraiser>().HasData(new Fundraiser
             {
                 Id = fundId,
                 Name = "Pauls Extension",
                 Amount = 10000,
                 CreatedDate = DateTimeOffset.Now.AddDays(-3)
             });

            modelBuilder.Entity<Donation>().HasData(new Donation
            {
                Id = Guid.NewGuid(),
                FundraiserId = fundId,
                DonorId = donorId,
                Amount = 40,
                DonationDate = DateTimeOffset.Now
            });
        }
    }
}
