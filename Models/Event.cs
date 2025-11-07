using System;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public string? Title { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string? Venue { get; set; } = string.Empty;
        public string? Organizer { get; set; } = string.Empty;
    }
}
