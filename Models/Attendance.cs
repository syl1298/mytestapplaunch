using System.ComponentModel.DataAnnotations;

namespace MyBlazorApp.Models;

public class Attendance
{
    public int Id { get; set; }
    
    [Required]
    public int EventId { get; set; }
    
    [Required]
    public int RegistrationId { get; set; }
    
    public string AttendeeEmail { get; set; } = string.Empty;
    
    public DateTime CheckInTime { get; set; }
    
    public DateTime? CheckOutTime { get; set; }
    
    public AttendanceStatus Status { get; set; } = AttendanceStatus.CheckedIn;
    
    public string Notes { get; set; } = string.Empty;
}

public enum AttendanceStatus
{
    CheckedIn,
    CheckedOut,
    NoShow
}
