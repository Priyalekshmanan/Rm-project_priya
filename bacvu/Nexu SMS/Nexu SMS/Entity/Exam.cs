using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Nexu_SMS.Repository;

namespace Nexu_SMS.Entity
{
    public class Exam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //disable the identity
        [Column("Exam ID")]
        public string examId { get; set; }

        [Column("Exam Name")]
        public string examName { get; set; }


        [Column("Exam Time")]
        public string examTime { get; set; }

        [Column("Exam Date")]
        public DateTime date { get; set; }

        [Column("Class ID")]
        public string classId { get; set; }

        [Column("Subject ID")]
        public string subId { get; set; }

        //Navigation

        [ForeignKey("classId")]
        public ClassManagement? classManagement { get; set; }

        [ForeignKey("subId")]
        public Subject? subject { get; set; }
    }
}
