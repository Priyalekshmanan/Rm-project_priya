using AutoMapper;
using Nexu_SMS.DTO;
using Nexu_SMS.Entity;

namespace Nexu_SMS.Profiles
{
    public class TAttendanceProfile:Profile
    {
        public TAttendanceProfile() 
        {

            CreateMap<TAttendance, TAttendancedto>()
             .ForMember(dest => dest.attendanceId, opt => opt.MapFrom(src => src.attendanceId))
            .ReverseMap();
            CreateMap<TAttendancedto, TAttendance>();
            //CreateMap<StudentUpdatedto, Student>();
        }
    }
}
