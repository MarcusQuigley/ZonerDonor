using AutoMapper;
using Models = ZonerDonor.Core.Models;

namespace ZonerDonor.Profiles
{
    public class FundraiserProfile : Profile
    {
        public FundraiserProfile()
        {
            CreateMap<Models.Fundraiser, Entities.FundraiserDto>()
                .ReverseMap()
                ;
               
        }
    }
}
