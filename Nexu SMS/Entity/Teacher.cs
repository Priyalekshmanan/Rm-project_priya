using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexu_SMS.Entity
{
    [Table("Teachers")]
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Enter Name")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string teacherId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string teacherFirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string teacherLastName { get; set; }

        [Required]
        public DateTime dateOfBirth { get; set; }

        [Required(ErrorMessage = "Enter Gender")]
        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string teacherGender { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string teacherSubjectTaught { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        [EmailAddress(ErrorMessage = "Invalid EmailId")]
        public string teacherEmail { get; set; }

        [Required(ErrorMessage = "Enter Mobile")]
        [RegularExpression("[6-9]\\d{9}", ErrorMessage = "Invalid Mobile No")]
        public string teacherPhone { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(60)]
        public string teacherAddress { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string teacherClass { get; set; }
    }
}
