using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Nexu_SMS.Entity
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Notification ID")]
        public string notificationId { get; set; }

        [Column("Message")]
        public string? Message { get; set; }


        [Column("Notification Time")]
        public DateTime Date { get; set; }

        [Column("Role")]
        public string? Role { get; set; }

    }
}
