using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexu_SMS.Repository
{
    [Table("AdmissionNoTable")]
    public class AdmissionNo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //disable the identity
        [Column(TypeName ="varchar")]
        [StringLength(30)]
        public   string  admissionNo {  get; set; }
    }
}
