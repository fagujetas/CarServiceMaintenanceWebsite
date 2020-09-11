using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class DealerProfile : Profile
    {
        public DealerProfile()
        {
            
            //Source -> Target
            CreateMap<DealerInfo, DealerReadDto>();
        }
    }
}