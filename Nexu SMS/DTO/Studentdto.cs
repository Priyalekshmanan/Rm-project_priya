using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nexu_SMS.DTO
{
    public class Studentdto
    {

       
        public string id { get; set; }

       
        public string fName { get; set; }

     
        public string lName { get; set; }

        public DateTime dob { get; set; }

        [Column("Gender")]
        public string gender { get; set; }

        [Column("Class")]
        public int clss { get; set; }

        [Column("Section", TypeName = "varchar")]

        [StringLength(50)]
        public string section { get; set; }

    }
}
