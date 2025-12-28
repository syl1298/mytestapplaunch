namespace MyBlazorApp.Models;

public class UserSession
{
    public string SessionId { get; set; } = Guid.NewGuid().ToString();
    
    public string UserEmail { get; set; } = string.Empty;
    
    public string UserName { get; set; } = string.Empty;
    
    public DateTime SessionStartTime { get; set; } = DateTime.Now;
    
    public DateTime LastActivityTime { get; set; } = DateTime.Now;
    
    public bool IsActive { get; set; } = true;
    
    public Dictionary<string, object> SessionData { get; set; } = new();
    
    public List<int> ViewedEvents { get; set; } = new();
    
    public List<int> RegisteredEvents { get; set; } = new();
}
