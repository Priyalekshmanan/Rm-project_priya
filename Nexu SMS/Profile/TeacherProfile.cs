using Nexu_SMS.Entity;
using AutoMapper;
using Nexu_SMS.DTO;


namespace Nexu_SMS.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile() {
            
          
              
            CreateMap<Teacher, Teacherdto>()
             .ForMember(dest => dest.teacherid, opt => opt.MapFrom(src => src.teacherId))
            .ReverseMap();
            CreateMap<Teacherdto, Teacher>();

          /*  CreateMap<Teacher, Teacherdto>();*/

            CreateMap<TeacherUpdatedto, Teacher>();

        }

        }
    }

