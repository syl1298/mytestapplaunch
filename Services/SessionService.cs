using MyBlazorApp.Models;

namespace MyBlazorApp.Services;

public interface ISessionService
{
    UserSession CurrentSession { get; }
    void InitializeSession(string userName, string userEmail);
    void UpdateActivity();
    void AddViewedEvent(int eventId);
    void AddRegisteredEvent(int eventId);
    void SetSessionData(string key, object value);
    T? GetSessionData<T>(string key);
    void EndSession();
    TimeSpan GetSessionDuration();
    bool IsSessionExpired(int timeoutMinutes = 30);
}

public class SessionService : ISessionService
{
    private UserSession? _currentSession;

    public UserSession CurrentSession
    {
        get
        {
            if (_currentSession == null || !_currentSession.IsActive)
            {
                InitializeSession("Guest", "guest@eventease.com");
            }
            return _currentSession!;
        }
    }

    public void InitializeSession(string userName, string userEmail)
    {
        _currentSession = new UserSession
        {
            UserName = userName,
            UserEmail = userEmail,
            SessionStartTime = DateTime.Now,
            LastActivityTime = DateTime.Now,
            IsActive = true
        };
    }

    public void UpdateActivity()
    {
        if (_currentSession != null && _currentSession.IsActive)
        {
            _currentSession.LastActivityTime = DateTime.Now;
        }
    }

    public void AddViewedEvent(int eventId)
    {
        if (_currentSession != null && !_currentSession.ViewedEvents.Contains(eventId))
        {
            _currentSession.ViewedEvents.Add(eventId);
            UpdateActivity();
        }
    }

    public void AddRegisteredEvent(int eventId)
    {
        if (_currentSession != null && !_currentSession.RegisteredEvents.Contains(eventId))
        {
            _currentSession.RegisteredEvents.Add(eventId);
            UpdateActivity();
        }
    }

    public void SetSessionData(string key, object value)
    {
        if (_currentSession != null)
        {
            _currentSession.SessionData[key] = value;
            UpdateActivity();
        }
    }

    public T? GetSessionData<T>(string key)
    {
        if (_currentSession?.SessionData.TryGetValue(key, out var value) == true)
        {
            return (T?)value;
        }
        return default;
    }

    public void EndSession()
    {
        if (_currentSession != null)
        {
            _currentSession.IsActive = false;
        }
    }

    public TimeSpan GetSessionDuration()
    {
        return _currentSession != null
            ? DateTime.Now - _currentSession.SessionStartTime
            : TimeSpan.Zero;
    }

    public bool IsSessionExpired(int timeoutMinutes = 30)
    {
        if (_currentSession == null) return true;
        
        var inactiveTime = DateTime.Now - _currentSession.LastActivityTime;
        return inactiveTime.TotalMinutes > timeoutMinutes;
    }
}
