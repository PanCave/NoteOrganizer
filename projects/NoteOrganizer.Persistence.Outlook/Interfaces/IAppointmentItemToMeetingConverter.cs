using Microsoft.Office.Interop.Outlook;
using NoteOrganizer.BL.BO.Interfaces;

namespace NoteOrganizer.Persistence.Outlook.Interfaces
{
  public interface IAppointmentItemToMeetingConverter
  {
    IMeeting Convert(AppointmentItem appointmentItem);
  }
}