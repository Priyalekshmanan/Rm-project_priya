namespace Nexu_SMS.Models
{
    public class PublishResult
    {
        public string stu_id { get; set; }
        public string examId { get; set; }
        public string sub_Id { get; set; }
        public float totalMarks { get; set; }
        public List<SubjectResult> subjectResults { get; set; }
    }

    public class SubjectResult
    {
        public string sub_Id { get; set; }
        public float marks { get; set; }
    }

}
