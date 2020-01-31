using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZonerDonor.Core.Models;

namespace ZonerDonor.Services.MockRepos
{
    public class MockDonationRepository : IDonationRepository, IDisposable
    {
        IList<Donation> Donations { get; set; }
        FundContext dbContext;
        readonly IFundraiserRepository fundraiserRepository;
        readonly IDonorRepository donorRepository;

        public MockDonationRepository(FundContext dbContext,
            IFundraiserRepository fundraiserRepository,
            IDonorRepository donorRepository)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.fundraiserRepository = fundraiserRepository ?? throw new ArgumentNullException(nameof(fundraiserRepository));
            this.donorRepository = donorRepository ?? throw new ArgumentNullException(nameof(donorRepository));

            Donations = new List<Donation> {
                new Donation{
                    FundraiserId = fundraiserRepository.GetFundraisersAsync().Result.First().Id,
                    DonorId = donorRepository.GetDonorsAsync().Result.First().Id,
                    Amount = 10,
                    DonationDate =DateTimeOffset.Now
                },

                new Donation{
                    FundraiserId = fundraiserRepository.GetFundraisersAsync().Result.First().Id,
                    DonorId = donorRepository.GetDonorsAsync().Result.Last().Id,
                    Amount = 40,
                    DonationDate =DateTimeOffset.Now
                },
            };
        }
        public void AddDonation(Donation donation)
        {
            if (donation == null)
            {
                throw new ArgumentNullException(nameof(donation));
            }
            dbContext.Donations.Add(donation);
        }

        public async Task<IEnumerable<Donation>> GetDonationsByDonorAsync(Guid donorId)
        {
            return await dbContext.Donations
                            .Where(d => d.DonorId == donorId)
                            .ToArrayAsync();
        }

        public async Task<IEnumerable<Donation>> GetDonationsByFundAsync(Guid fundId)
        {
            return await dbContext.Donations
                           .Where(d => d.FundraiserId == fundId)
                           .ToArrayAsync();
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
    }
}
