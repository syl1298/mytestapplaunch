using MyBlazorApp.Models;

namespace MyBlazorApp.Services;

public interface IEventDataService
{
    List<Event> GetAllEvents();
    Event? GetEventById(int id);
    void AddEvent(Event evt);
    void UpdateEvent(Event evt);
    void DeleteEvent(int id);
    
    List<Registration> GetAllRegistrations();
    List<Registration> GetRegistrationsByEvent(int eventId);
    Registration? GetRegistrationById(int id);
    void AddRegistration(Registration registration);
    void UpdateRegistration(Registration registration);
    void CancelRegistration(int id);
    
    List<Attendance> GetAllAttendances();
    List<Attendance> GetAttendancesByEvent(int eventId);
    void RecordAttendance(Attendance attendance);
    void UpdateAttendance(Attendance attendance);
}

public class EventDataService : IEventDataService
{
    private readonly List<Event> _events = new();
    private readonly List<Registration> _registrations = new();
    private readonly List<Attendance> _attendances = new();

    public EventDataService()
    {
        InitializeSampleData();
    }

    private void InitializeSampleData()
    {
        // Sample events
        _events.AddRange(new List<Event>
        {
            new Event 
            { 
                Id = 1, 
                EventName = "Tech Conference 2025", 
                Date = new DateTime(2025, 3, 15, 9, 0, 0), 
                Location = "San Francisco Convention Center",
                Description = "Annual technology conference featuring the latest innovations"
            },
            new Event 
            { 
                Id = 2, 
                EventName = "Music Festival", 
                Date = new DateTime(2025, 6, 20, 18, 0, 0), 
                Location = "Central Park, New York",
                Description = "Three-day music festival with international artists"
            },
            new Event 
            { 
                Id = 3, 
                EventName = "Food & Wine Expo", 
                Date = new DateTime(2025, 4, 10, 12, 0, 0), 
                Location = "Chicago Food Hall",
                Description = "Culinary experience with local and international cuisine"
            }
        });

        // Sample registrations
        _registrations.AddRange(new List<Registration>
        {
            new Registration 
            { 
                Id = 1, 
                EventId = 1, 
                Name = "John Smith",
                Email = "john.smith@email.com",
                ContactNumber = "555-0101",
                RegisteredDate = DateTime.Now.AddDays(-5),
                Status = RegistrationStatus.Confirmed
            },
            new Registration 
            { 
                Id = 2, 
                EventId = 1, 
                Name = "Sarah Johnson",
                Email = "sarah.j@email.com",
                ContactNumber = "555-0102",
                RegisteredDate = DateTime.Now.AddDays(-4),
                Status = RegistrationStatus.Confirmed
            }
        });
    }

    // Event methods
    public List<Event> GetAllEvents() => _events;
    
    public Event? GetEventById(int id) => _events.FirstOrDefault(e => e.Id == id);
    
    public void AddEvent(Event evt)
    {
        evt.Id = _events.Any() ? _events.Max(e => e.Id) + 1 : 1;
        _events.Add(evt);
    }
    
    public void UpdateEvent(Event evt)
    {
        var existing = _events.FirstOrDefault(e => e.Id == evt.Id);
        if (existing != null)
        {
            var index = _events.IndexOf(existing);
            _events[index] = evt;
        }
    }
    
    public void DeleteEvent(int id)
    {
        var evt = _events.FirstOrDefault(e => e.Id == id);
        if (evt != null) _events.Remove(evt);
    }

    // Registration methods
    public List<Registration> GetAllRegistrations() => _registrations;
    
    public List<Registration> GetRegistrationsByEvent(int eventId) => 
        _registrations.Where(r => r.EventId == eventId).ToList();
    
    public Registration? GetRegistrationById(int id) => 
        _registrations.FirstOrDefault(r => r.Id == id);
    
    public void AddRegistration(Registration registration)
    {
        registration.Id = _registrations.Any() ? _registrations.Max(r => r.Id) + 1 : 1;
        registration.RegisteredDate = DateTime.Now;
        _registrations.Add(registration);
    }
    
    public void UpdateRegistration(Registration registration)
    {
        var existing = _registrations.FirstOrDefault(r => r.Id == registration.Id);
        if (existing != null)
        {
            var index = _registrations.IndexOf(existing);
            _registrations[index] = registration;
        }
    }
    
    public void CancelRegistration(int id)
    {
        var registration = _registrations.FirstOrDefault(r => r.Id == id);
        if (registration != null)
        {
            registration.Status = RegistrationStatus.Cancelled;
        }
    }

    // Attendance methods
    public List<Attendance> GetAllAttendances() => _attendances;
    
    public List<Attendance> GetAttendancesByEvent(int eventId) =>
        _attendances.Where(a => a.EventId == eventId).ToList();
    
    public void RecordAttendance(Attendance attendance)
    {
        attendance.Id = _attendances.Any() ? _attendances.Max(a => a.Id) + 1 : 1;
        attendance.CheckInTime = DateTime.Now;
        _attendances.Add(attendance);
        
        // Update registration status
        var registration = _registrations.FirstOrDefault(r => r.Id == attendance.RegistrationId);
        if (registration != null)
        {
            registration.AttendanceConfirmed = true;
            registration.Status = RegistrationStatus.Attended;
        }
    }
    
    public void UpdateAttendance(Attendance attendance)
    {
        var existing = _attendances.FirstOrDefault(a => a.Id == attendance.Id);
        if (existing != null)
        {
            var index = _attendances.IndexOf(existing);
            _attendances[index] = attendance;
        }
    }
}
