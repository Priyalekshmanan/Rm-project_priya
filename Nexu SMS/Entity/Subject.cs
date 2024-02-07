using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nexu_SMS.Entity
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //disable the identity
        [Column("Subject Id")]
        public string subId { get; set; }

        [Column("Subject Name")]
        public string subName { get; set; }


        //navigation
      /*  [ForeignKey("Stuid")]
        public Student Student { get; set; }*/
    }
}
