using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZonerDonor.Core.Models;

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

        public async Task<IEnumerable<Fundraiser>> GetFundraisersAsync()
        {
            return await context.Fundraisers.ToArrayAsync();
        }

        public async Task<IEnumerable<Fundraiser>> GetLatestFundraisersAsync(int numberToGet = 3)
        {
            return await context.Fundraisers
                                    .Take(numberToGet)
                                    .ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync() > 0);
        }
    }
}
