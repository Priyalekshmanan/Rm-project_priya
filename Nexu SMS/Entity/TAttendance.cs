using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nexu_SMS.Entity
{
    [Table("Teacher_Attendance_Table")]
    public class TAttendance
    {
        [Key]
        public Guid attendanceId { get; set; }
       
        [Required]
        public string teacherId { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public bool status { get; set; }

        //// navigation 
        [ForeignKey("teacherId")]
        public Teacher? teacher { get; set; }


    }
}
