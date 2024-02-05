using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nexu_SMS.Entity
{
    public class ExamSchdule
    {

        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //disable the identity
        public string Exam_id {  get; set; }
        [Column("Exam_Name")]
        public string Exam_name { get; set; }
        public DateTime Exam_date { get; set; }

    }
}
