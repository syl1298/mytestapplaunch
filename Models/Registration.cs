using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Models;

public class Registration
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Event is required")]
    public int EventId { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Contact number is required")]
    [Phone(ErrorMessage = "Invalid phone number")]
    [StringLength(20, MinimumLength = 10, ErrorMessage = "Contact number must be between 10 and 20 characters")]
    public string ContactNumber { get; set; } = string.Empty;
    
    public DateTime RegisteredDate { get; set; }
    
    public RegistrationStatus Status { get; set; } = RegistrationStatus.Pending;
    
    public bool AttendanceConfirmed { get; set; }
}

public enum RegistrationStatus
{
    Pending,
    Confirmed,
    Cancelled,
    Attended
}
