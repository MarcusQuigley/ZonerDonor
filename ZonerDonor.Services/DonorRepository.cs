using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZonerDonor.Core.Models;
using ZonerDonor.Utils.Extensions;

namespace ZonerDonor.Services
{
    public class DonorRepository : IDonorRepository
    {
        readonly FundContext context;

        public DonorRepository(FundContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddDonor(Donor donor)
        {
            if (donor == null)
            {
                throw new ArgumentNullException(nameof(donor));
            }
            context.Donors.Add(donor);
        }

        public async Task<IEnumerable<Donor>> GetDonorsAsync()
        {
            return await context.Donors.ToArrayAsync();
        }

        public async Task<int> CountAsync()
        {
            return await context.Fundraisers.CountAsync();
        }

        public async Task<Donor> GetRandomDonorAsync()
        {
            int count = await CountAsync();
            return await context.Donors
                                     .Skip(count.RandomNumberLessThan())
                                      //.Take(1)
                                      .FirstAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync() > 0);
        }
    }
}
