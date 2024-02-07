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






        [ForeignKey("examId")]
        public Exam? exam { get; set; }

        [ForeignKey("subjectId")]
        public Subject? subject { get; set; }

        [ForeignKey("studentId")]
        public Student? student { get; set; }
    }
}
