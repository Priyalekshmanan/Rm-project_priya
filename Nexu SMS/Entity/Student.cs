using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Nexu_SMS.Entity
{
    public class Student
    {
        [Key]
        [Column(TypeName ="varchar")]
        [StringLength(30)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //disable the identity
        public string id { get; set; }

        [Column("First Name")]
        public string fName { get; set; }

        [Column("Last Name")]
        public string lName { get; set; }

        public DateTime dob { get; set; }

    }
}
