using System.ComponentModel.DataAnnotations;

namespace Nexu_SMS.DTO
{
    public class SAttendancedto
    {

        public string classId { get; set; }

        public string studentId { get; set; }

        public bool status { get; set; }
    }
}
