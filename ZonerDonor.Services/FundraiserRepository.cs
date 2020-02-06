using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZonerDonor.Core.Models;
using ZonerDonor.Utils.Extensions;

namespace ZonerDonor.Services
{
    public class FundraiserRepository : IFundraiserRepository
    {
        readonly FundContext context;

        public FundraiserRepository(FundContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddFundRaiser(Fundraiser fundraiser)
        {
            if (fundraiser == null)
            {
                throw new ArgumentNullException(nameof(fundraiser));
            }
            context.Fundraisers.Add(fundraiser);
        }

        public async Task<Fundraiser> GetFundraiserAsync(Guid fundId)
        {
            return await context.Fundraisers.FirstOrDefaultAsync(f => f.Id == fundId);
        }

        public async Task<Fundraiser> GetRandomFundraiserAsync()
        {
            int count = await CountAsync();
            return await context.Fundraisers 
                                     .Skip(count.RandomNumberLessThan())
                                     .FirstAsync();
        }
 
        public async Task<IEnumerable<Fundraiser>> GetFundraisersAsync()
        {
            return await context.Fundraisers.ToArrayAsync();
        }

        public async Task<IEnumerable<Fundraiser>> GetLatestFundraisersAsync(int numberToGet = 3)
        {
            return await context.Fundraisers
                                    .OrderByDescending(f=>f.CreatedDate)
                                    .Take(numberToGet)
                                    .ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync() > 0);
        }

        public async Task UpdateFundTotalAsync(Guid fundId, decimal donationAmount)
        {
            var fundraiser = await GetFundraiserAsync(fundId);
            if (fundraiser == null)
            {
                throw new ArgumentException("Fund does not exist");
            }
            fundraiser.UpdateTotal(donationAmount);
            context.Fundraisers.Update(fundraiser);
            await context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await context.Fundraisers.CountAsync();
        }

        public async Task<IEnumerable<Guid>> GetFundraiserIdsAsync()
        {
            return await context.Fundraisers
                                .Select(f=>f.Id)
                                .ToArrayAsync();
        }
    }
}
