using AutoMapper;
using Nexu_SMS.DTO;
using Nexu_SMS.Entity;

namespace Nexu_SMS.Profiles
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, Studentdto>()
             .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
            .ReverseMap();
            CreateMap<Studentdto, Student>();
            CreateMap<StudentUpdatedto, Student>();
           



        }
    }
}
