using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nexu_SMS.DTO
{
    public class TeacherUpdatedto
    {
        public string teacherid { get; set; }
        public string teacherFirstName { get; set; }

        public string teacherLastName { get; set; }
        public DateTime dateOfBirth { get; set; }


        public string teacherGender { get; set; }


        public string teacherSubjectTaught { get; set; }

        public string teacherEmail { get; set; }
        public string teacherClass { get; set; }
        public string teacherPhone { get; set; }

      
        public string teacherAddress { get; set; }
    }
}
