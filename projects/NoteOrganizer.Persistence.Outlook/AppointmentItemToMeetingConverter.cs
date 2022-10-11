using Microsoft.Office.Interop.Outlook;
using NoteOrganizer.BL.BO;
using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.Persistence.Outlook.Interfaces;

namespace NoteOrganizer.Persistence.Outlook
{
  public class AppointmentItemToMeetingConverter : IAppointmentItemToMeetingConverter
  {
    public IMeeting Convert(AppointmentItem appointmentItem)
    {
      string title = appointmentItem.Subject;
      TimeOnly startTime = TimeOnly.FromDateTime(appointmentItem.Start);
      TimeOnly endTime = TimeOnly.FromDateTime(appointmentItem.End);
      string identifier = appointmentItem.GlobalAppointmentID;
      string notes = string.Empty;

      IMeeting meeting = new Meeting(title, startTime, endTime, identifier, notes);
      return meeting;
    }
  }
}