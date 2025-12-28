namespace MyBlazorApp.Models;

public class Event
{
    public int Id { get; set; }
    public string EventName { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
