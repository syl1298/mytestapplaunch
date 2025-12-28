# EventEase - Quick Start Guide

## 🚀 Running the Application

```bash
cd C:\Users\sinye\MyBlazorApp
dotnet run --urls "http://localhost:5280"
```

Open browser to: **http://localhost:5280**

---

## 📋 Feature Overview

### 1. Registration Form (`/register`)
- **Purpose**: Register users for events with full validation
- **Features**:
  - Email, phone, name validation
  - Duplicate prevention
  - Real-time error feedback
  - Success confirmations

**Test It**:
- Try empty form → See validation errors
- Enter invalid email → See error
- Register successfully → See confirmation

---

### 2. Session Tracker (Automatic)
- **Purpose**: Track user activity and state
- **Features**:
  - Auto-tracks viewed events
  - Tracks registrations
  - 30-minute timeout
  - Session continuity

**Test It**:
- Go to `/integration-test`
- View session info
- Navigate pages → Session persists
- Run session tests

---

### 3. Attendance Tracker (`/attendance`)
- **Purpose**: Track event check-ins
- **Features**:
  - Check-in/check-out
  - Attendance statistics
  - Quick check-in for registered users
  - Real-time metrics

**Test It**:
- Select event
- Check in attendee
- View statistics update
- Mark check-out

---

## ✅ Running Tests

### Integration Tests (`/integration-test`)
```
Run All Tests → 19/19 should pass

Categories:
- Registration (5 tests)
- Session Management (6 tests)
- Attendance (4 tests)
- Performance (4 tests)
```

### Original Tests (`/test`)
```
Run All Tests → 16/16 should pass

Categories:
- Validation (5 tests)
- Edge Cases (7 tests)
- Performance (4 tests)
```

**Total**: 35 tests - all should pass ✅

---

## 🎯 Key Pages

| Page | URL | Purpose |
|------|-----|---------|
| Home | `/` | Landing page |
| Events | `/events` | Browse/search events |
| Register | `/register` | Registration form |
| Registrations | `/registrations` | View all registrations |
| Attendance | `/attendance` | Track attendance |
| Tests | `/test` | Original test suite |
| Integration Tests | `/integration-test` | Full integration tests |

---

## ⚡ Quick Feature Tests

### Test Registration Form:
1. Go to `/register`
2. Click "Register for Event" without filling form
3. ✅ Should see validation errors
4. Fill form with valid data
5. ✅ Should see success message

### Test Session Continuity:
1. Go to `/integration-test`
2. Note Session ID
3. Navigate to `/events`
4. Return to `/integration-test`
5. ✅ Session ID should be same

### Test Attendance:
1. Go to `/attendance`
2. Select "Tech Conference 2025"
3. Click "Check In Attendee"
4. Enter "john.smith@email.com"
5. ✅ Should check in successfully

---

## 🔍 Validation Examples

### Valid Registration:
```
Name: John Doe
Email: john.doe@email.com
Phone: 555-123-4567
Event: Tech Conference 2025
→ SUCCESS ✅
```

### Invalid Email:
```
Email: notanemail
→ ERROR: Invalid email address ❌
```

### Duplicate Registration:
```
Email: john.smith@email.com (already registered)
Event: Tech Conference 2025
→ ERROR: Email already registered ❌
```

---

## 📊 Session Information

View current session at any time:
- **Location**: Bottom of `/integration-test` page
- **Shows**:
  - Session ID
  - User name/email
  - Session duration
  - Active status
  - Viewed events
  - Registered events

---

## 🛠️ Architecture Quick Reference

### Services:
- **SessionService**: Manages user sessions
- **EventDataService**: Manages all data (events, registrations, attendance)

### Models:
- **Event**: Event information
- **Registration**: User registrations with validation
- **Attendance**: Check-in/check-out records
- **UserSession**: Session state

### Key Features:
- **Dependency Injection**: Services injected via @inject
- **Data Annotations**: Validation on models
- **State Management**: Singleton services
- **Error Handling**: Try-catch + user messages

---

## 📈 Expected Performance

- **Page Load**: < 500ms
- **Registration Submit**: < 1s
- **Session Operations**: < 1ms
- **Attendance Check-in**: < 500ms
- **Filter 1000 Events**: < 5ms
- **All Tests**: ~5 seconds total

---

## ✨ Best Practices Applied

✅ Input validation on all forms  
✅ Error handling throughout  
✅ User feedback (success/error messages)  
✅ Loading states  
✅ Clean code structure  
✅ Separation of concerns  
✅ Interface-based design  
✅ Comprehensive testing  
✅ Performance optimization  
✅ No unnecessary dependencies  

---

## 🎓 For Developers

### Adding a New Feature:

1. **Create Model** (if needed): `Models/YourModel.cs`
2. **Update Service**: Add methods to `EventDataService.cs`
3. **Create Page**: `Pages/YourPage.razor`
4. **Add Navigation**: Update `NavMenu.razor`
5. **Add Tests**: Add to `IntegrationTest.razor`

### Example - Add New Field to Registration:

```csharp
// 1. Update Model
public string Company { get; set; } = string.Empty;

// 2. Add to Form
<InputText @bind-Value="registration.Company" />

// 3. Add Validation (if needed)
[Required]
public string Company { get; set; } = string.Empty;
```

---

## 🚨 Troubleshooting

### Build Errors?
```bash
dotnet clean
dotnet build
```

### Can't Access Page?
- Check URL is correct
- Verify page has `@page` directive
- Check NavMenu has link

### Tests Failing?
- Run `/integration-test` → See which tests fail
- Check error messages
- Verify data service initialization

### Session Not Persisting?
- SessionService is Singleton (should persist)
- Check browser console for errors
- Verify no exceptions thrown

---

## 📞 Quick Commands

```bash
# Build
dotnet build

# Run (default port)
dotnet run

# Run (custom port)
dotnet run --urls "http://localhost:5280"

# Clean build
dotnet clean && dotnet build

# Check for errors
dotnet build --no-incremental
```

---

## 🎉 Success Criteria

Application is working correctly if:

✅ All 35 tests pass (16 + 19)  
✅ Registration form validates properly  
✅ Sessions persist across navigation  
✅ Attendance tracking works  
✅ Performance is < 5ms for filters  
✅ No console errors  
✅ All pages load correctly  

---

**Status**: ✅ Production Ready  
**Version**: 2.0.0  
**Last Updated**: December 28, 2025
