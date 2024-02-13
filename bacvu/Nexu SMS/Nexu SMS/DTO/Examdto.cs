using Nexu_SMS.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nexu_SMS.DTO
{
    public class Examdto
    {

        
        public string examId { get; set; }

 
        public string examName { get; set; }
        public string examTime { get; set; }

        public string classId { get; set; }


        public DateTime date { get; set; }
        public string subId { get; set; }


    }
}
