using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZonerDonor.Core.Models;

namespace ZonerDonor.Services
{
    public class DonationRepository : IDonationRepository
    {
        readonly FundContext context;

        public DonationRepository(FundContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddDonation(Donation donation)
        {
            if (donation == null)
            {
                throw new ArgumentNullException(nameof(donation));
            }
            context.Donations.Add(donation);
        }

        public async Task<IEnumerable<Donation>> GetDonationsByDonorAsync(Guid donorId)
        {
            return await context.Donations
                                 .Where(d => d.DonorId == donorId)
                                 .ToArrayAsync();
        }

        public async Task<IEnumerable<Donation>> GetDonationsByFundAsync(Guid fundId)
        {
            return await context.Donations
                                    .Where(d => d.FundraiserId == fundId)
                                    .ToArrayAsync();
        }

        public async Task<IEnumerable<Donor>> GetDonorsAsync()
        {
            return await context.Donors.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync() > 0);
        }
    }
}
