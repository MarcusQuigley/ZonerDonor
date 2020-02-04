using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZonerDonor.Core.Models;

namespace ZonerDonor.Services
{
    public interface IFundraiserRepository
    {
        Task<Fundraiser> GetFundraiserAsync(Guid fundId);
        Task<Fundraiser> GetRandomFundraiserAsync();
        Task<IEnumerable<Fundraiser>> GetFundraisersAsync();
        Task<IEnumerable<Fundraiser>> GetLatestFundraisersAsync(int numberToGet = 3);
        void AddFundRaiser(Fundraiser fundraiser);
        Task UpdateFundTotalAsync(Guid fundId, decimal donationAmount);
        Task<bool> SaveChangesAsync();
    }
}
