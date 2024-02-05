using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Nexu_SMS.Entity
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string userId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string userName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string password { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string role { get; set; }
    }
}
