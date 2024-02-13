using AutoMapper;
using Nexu_SMS.DTO;
using Nexu_SMS.Entity;

namespace Nexu_SMS.Profiles
{
    public class ExamProfile:Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam, Examdto>()
             .ForMember(dest => dest.examId, opt => opt.MapFrom(src => src.examId))
            .ReverseMap();
            CreateMap<Examdto, Exam>();
           




        }
    }
}
