namespace EventManagement.Models
{
    public class LoginRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; // optional, depending on your use
    }
}
