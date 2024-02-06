using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexu_SMS.Entity
{
    public class Result
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //disable the identity
        public int Res_Id { get; set; }
        public float marks { get; set; }
      public int exam_Id { get; set; }

        [ForeignKey("exam_Id")]
  
        public Exam? exam { get; set; }


     /*   public string sub_Id { get; set; }
        [ForeignKey("sub_Id")]
        public Subject? subject { get; set; }*/

        public string stu_id { get; set; }
        [ForeignKey("stu_id")]
        public Student? student { get; set; }
    }
}
