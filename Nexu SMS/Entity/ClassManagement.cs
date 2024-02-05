using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexu_SMS.Entity
{
    public class ClassModel
    {
        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //disable the identity
        public int ClassId { get; set; }
        [Column("Class Name")]
        public string ClassName { get; set; }
        [Column("Schedule")]
        public string Schedule { get; set; }

       /* //Navigation property
        [ForeignKey("teacherid")]
*/
        public string Teacherid { get; set; }

        public List<string> Student { get; set; } = new List<string>();
    }
}