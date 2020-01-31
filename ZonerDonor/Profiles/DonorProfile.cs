using AutoMapper;
using Models = ZonerDonor.Core.Models;

namespace ZonerDonor.Profiles
{
    public class DonorProfile : Profile
    {
        public DonorProfile()
        {
            CreateMap<Models.Donor, Entities.DonorDto>()
                .ReverseMap()
                ;
               
        }
    }
}
