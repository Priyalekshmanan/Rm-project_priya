using AutoMapper;
using Nexu_SMS.DTO;
using Nexu_SMS.Entity;

namespace Nexu_SMS.Profiles
{
    public class ResultProfile:Profile
    {
        public ResultProfile()
        {

            CreateMap<Result, Resultdto>()
             .ForMember(dest => dest.ResultId, opt => opt.MapFrom(src => src.ResultId))
            .ReverseMap();
            CreateMap<Resultdto, Result>();

        }
    }
}
