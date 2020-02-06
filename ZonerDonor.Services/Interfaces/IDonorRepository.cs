using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZonerDonor.Core.Models;

namespace ZonerDonor.Services
{
    public interface IDonorRepository
    {
        void AddDonor(Donor donor);
        Task<Donor> GetRandomDonorAsync();
        Task<IEnumerable<Donor>> GetDonorsAsync();
        Task<IEnumerable<Guid>> GetDonorIdsAsync();
        Task<bool> SaveChangesAsync();
    }
}
