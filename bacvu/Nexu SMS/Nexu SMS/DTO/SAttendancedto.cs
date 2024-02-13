using System.ComponentModel.DataAnnotations;

namespace Nexu_SMS.DTO
{
    public class SAttendancedto
    {
       public Guid attendanceId { get; set; }
        public string classId { get; set; }

        public string studentId { get; set; }

     
        public DateTime date { get; set; }

        public bool status { get; set; }
    }
}
