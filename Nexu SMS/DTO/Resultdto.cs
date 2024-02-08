using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nexu_SMS.DTO
{
    public class Resultdto
    {

     
        public string ResultId { get; set; }

    
        public string examId { get; set; }

      
        public string studentId { get; set; }

    
        public string subjectId { get; set; }


        public float marks { get; set; }
    }
}
