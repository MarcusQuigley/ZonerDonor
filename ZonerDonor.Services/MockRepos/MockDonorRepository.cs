using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZonerDonor.Core.Models;

namespace ZonerDonor.Services.MockRepos
{
    public class MockDonorRepository : IDonorRepository, IDisposable
    {
        IList<Donor> Donors { get; set; }
        FundContext dbContext;

        public MockDonorRepository(FundContext context)
        {
            this.dbContext = context ?? throw new ArgumentNullException(nameof(context));

            Donors = new List<Donor> {
                new Donor{ Id=Guid.NewGuid(), Name = "Marcus", CreatedDate=DateTimeOffset.Now.AddDays(-30)},
                new Donor{ Id=Guid.NewGuid(), Name = "Eliza", CreatedDate=DateTimeOffset.Now},
                new Donor{ Id=Guid.NewGuid(), Name = "Camille", CreatedDate=DateTimeOffset.Now.AddDays(-3)},
            };
        }

        public void AddDonor(Donor donor)
        {
            if (donor == null)
            {
                throw new ArgumentNullException(nameof(donor));
            }
            dbContext.Donors.Add(donor);
        }

        public async Task<IEnumerable<Donor>> GetDonorsAsync()
        {
            return await dbContext.Donors.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await dbContext.SaveChangesAsync() > 0);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbContext == null)
                {
                    dbContext.Dispose();
                    dbContext = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<Donor> GetRandomDonorAsync()
        {
            throw new NotImplementedException();
        }
    }
}
