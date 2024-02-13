using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nexu_SMS.DTO
{
    public class StudentUpdatedto
    {
        public string id { get; set; }


        public string fName { get; set; }


        public string lName { get; set; }

        public DateTime dob { get; set; }

        public string gender { get; set; }

        public string semName { get; set; }


        public string streamName { get; set; }

        public string email { get; set; }
        public string number {  get; set; }

    }
}
