using AutoMapper;
using Nexu_SMS.DTO;
using Nexu_SMS.Entity;

namespace Nexu_SMS.Profiles
{
    public class ClassProfile:Profile
    {
        public ClassProfile()
        {
            CreateMap<ClassManagement, Classdto>()
             .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId))
            .ReverseMap();
            CreateMap<Classdto, ClassManagement>();
            //CreateMap<StudentUpdatedto, Student>();




        }
    }
}
