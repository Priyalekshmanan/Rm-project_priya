using AutoMapper;
using Nexu_SMS.DTO;
using Nexu_SMS.Entity;

namespace Nexu_SMS.Profiles
{
    public class SAttendanceProfile:Profile
    {
        public SAttendanceProfile() 
        {
            CreateMap<SAttendance, SAttendancedto>()
               .ForMember(dest => dest.attendanceId, opt => opt.MapFrom(src => src.attendanceId))
              .ReverseMap();
            CreateMap<SAttendancedto, SAttendance>();

           

        }
    }
}
