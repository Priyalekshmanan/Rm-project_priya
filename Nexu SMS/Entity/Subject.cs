using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexu_SMS.Entity
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //disable the identity
        public string sub_Id { get; set; }
        public string sub_Name { get; set; }



        /*        [ForeignKey("Stu_id")]
                public int Stu_id { get; set; }
                public Student Student { get; set; }*/
    }
}
