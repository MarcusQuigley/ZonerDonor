using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZonerDonor.Core.Models;

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

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync() > 0);
        }
    }
}
