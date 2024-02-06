using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexu_SMS.Entity
{
    public class Exam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //disable the identity
        public int exam_Id { get; set; }
        public string exam_Name { get; set; }

        public string examTime { get; set; }
       // public string ExamLocation { get; set; }

        public DateTime date { get; set; }
              
        
        public string class_Id { get; set; }
        [ForeignKey("class_Id")]
        public ClassModel? classModels { get; set; }

        public string sub_id {  get; set; }
        [ForeignKey("sub_id")]
        public Subject? sub { get; set; }

    }
}
