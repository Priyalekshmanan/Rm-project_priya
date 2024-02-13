namespace Nexu_SMS.Models
{
    public class DisplayTotalAttendance
    {
        public string teacherId { get; set; }
        public string studentId { get; set; }
        public int presentDays { get; set; }
        public int absentDays { get; set; }
        public int totalWorking { get; set; }
    }
}
