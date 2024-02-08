using System.ComponentModel.DataAnnotations;

namespace Nexu_SMS.DTO
{
    public class TAttendancedto
    {
        [Key]
        public Guid attendanceId { get; set; }

        [Required]
        public string teacherId { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public bool status { get; set; }

    }
}
