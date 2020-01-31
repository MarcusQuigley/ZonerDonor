using System.Collections.Generic;
using System.Threading.Tasks;
using ZonerDonor.Core.Models;

namespace ZonerDonor.Services
{
    public interface IFundraiserRepository
    {
        Task<IEnumerable<Fundraiser>> GetFundraisersAsync();
        void AddFundRaiser(Fundraiser fundraiser);
        Task<bool> SaveChangesAsync();
    }
}
