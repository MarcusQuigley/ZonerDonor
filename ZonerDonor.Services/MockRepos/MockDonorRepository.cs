using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZonerDonor.Core.Models;

namespace ZonerDonor.Services.MockRepos
{
    public class MockDonorRepository : IDonorRepository, IDisposable
    {
        IList<Donor> Donors { get; set; }

        public MockDonorRepository(FundContext context)
        {

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
            Donors.Add(donor);
        }

        public async Task<IEnumerable<Donor>> GetDonorsAsync()
        {
            await Task.Delay(1000);
            return Donors.ToArray();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

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
        public async Task<IEnumerable<Guid>> GetDonorIdsAsync()
        {
            return Donors
                        .Select(d => d.Id)
                        .ToArray();
        }
    }
}
