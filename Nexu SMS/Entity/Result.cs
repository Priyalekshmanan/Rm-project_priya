using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nexu_SMS.Entity
{
    public class Result
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //disable the identity
        [Column("Result ID")]
        public string ResultId { get; set; }

        [Column("Exam ID")]
        public string examId { get; set; }

        [Column("Student ID")]
        public string studentId { get; set; }

        [Column("Subject ID")]
        public string subjectId { get; set; }

        [Column("Marks")]
        public float marks { get; set; }






        /*[ForeignKey("exam_Id")]
        public Exam? exam { get; set; }

        [ForeignKey("sub_Id")]
        public Subject? subject { get; set; }

        public string stu_id { get; set; }
        [ForeignKey("stu_id")]
        public Student? student { get; set; }*/
    }
}
