using System.Collections.Generic;
using System.Threading.Tasks;
using ZonerDonor.Core.Models;

namespace ZonerDonor.Services
{
    public interface IFundraiserRepository
    {
        Task<IEnumerable<Fundraiser>> GetFundraisersAsync();
        Task<IEnumerable<Fundraiser>> GetLatestFundraisersAsync(int numberToGet = 3);
        void AddFundRaiser(Fundraiser fundraiser);
        Task<bool> SaveChangesAsync();
    }
}
