using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZonerDonor.Core.Models;

namespace ZonerDonor.Services
{
    public interface IDonationRepository
    {
        void AddDonation(Donation donation);
        Task<IEnumerable<Donation>> GetDonationsByFundAsync(Guid fundId);
        Task<IEnumerable<Donation>> GetDonationsByDonorAsync(Guid donorId);
        Task<bool> SaveChangesAsync();
    }
}
