using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZonerDonor.Core.Models;

namespace ZonerDonor.Services.MockRepos
{
    public class MockFundraiserRepository : IFundraiserRepository 
    {
        IList<Fundraiser> Fundraisers { get; set; }
        FundContext dbContext;

        public MockFundraiserRepository(FundContext dbContext)
        {
            // this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            Fundraisers = new List<Fundraiser> {
                new Fundraiser{ Id=Guid.NewGuid(), Name = "Pauls Extension", Amount=10000, CreatedDate=DateTimeOffset.Now.AddDays(-3)},
                new Fundraiser{ Id=Guid.NewGuid(), Name = "Joes Preop", Amount=23000, CreatedDate=DateTimeOffset.Now},
                new Fundraiser{ Id=Guid.NewGuid(), Name = "Big party!", Amount=10000, CreatedDate=DateTimeOffset.Now},
            };
        }

        public void AddFundRaiser(Fundraiser fundraiser)
        {
            if (fundraiser == null)
            {
                throw new ArgumentNullException(nameof(fundraiser));
            }

            Fundraisers.Add(fundraiser);
        }

        public async Task<IEnumerable<Fundraiser>> GetFundraisersAsync()
        {
            await Task.Delay(1000);
            return Fundraisers.ToArray();
        }

        public async Task<IEnumerable<Fundraiser>> GetLatestFundraisersAsync(int numberToGet = 3)
        {
            await Task.Delay(1000);
            return Fundraisers.Take(numberToGet)
                               .ToArray();
        }

        public async Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        //protected virtual void Dispose(bool disposing)
        //{
        //    //if (disposing)
        //    //{
        //    //    if (dbContext == null)
        //    //    {
        //    //        dbContext.Dispose();
        //    //        dbContext = null;
        //    //    }
        //    //}
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}


    }
}
