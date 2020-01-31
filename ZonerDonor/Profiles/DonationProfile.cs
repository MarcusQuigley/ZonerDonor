using AutoMapper;
using Models = ZonerDonor.Core.Models;

namespace ZonerDonor.Profiles
{
    public class DonationProfile : Profile
    {
        public DonationProfile()
        {
            CreateMap<Models.Donation, Entities.DonationDto>()
                .ReverseMap()
                ;
               
        }
    }
}
