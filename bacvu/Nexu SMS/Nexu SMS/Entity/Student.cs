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

        [Column("E-mail")]
        public string eMail { get; set; }

        [Column("Mobile No")]
        public string number { get; set; }

        [Column("DOB")]

        public DateTime dob { get; set; }

        [Column("Gender")]
        public string gender { get; set; }

        [Column("Semester")]
        public string semName { get; set; }


        [Column("Stream")]
        public string streamName { get; set; }


    }
}
