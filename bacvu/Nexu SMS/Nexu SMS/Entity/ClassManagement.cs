using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexu_SMS.Entity
{
    [Table("Class_Table")]
    public class ClassManagement
    {
        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //disable the identity
        public string ClassId { get; set; }
        [Column("Sem")]
        public string semName { get; set; }

        [Column("Branch")]
        public string streamName { get; set; }



        [Column("Teacher ID")]
        public string Teacherid { get; set; }

        //navigation prop
        [ForeignKey("Teacherid")]
        public Teacher? Teacher { get; set; }   


    }
}