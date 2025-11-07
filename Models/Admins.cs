using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models
{
    public class Admins
    {
        [Key]
        public int RegistrationId { get; set; }   // Primary Key

        [Required]
        public string UserName { get; set; } = string.Empty;

        public int EventId { get; set; }          // FK to Event table (optional)

        public string Status { get; set; } = "Pending";
    }
}
