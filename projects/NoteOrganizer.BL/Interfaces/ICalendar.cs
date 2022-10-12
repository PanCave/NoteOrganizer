using NoteOrganizer.BL.BO.Interfaces;

namespace NoteOrganizer.BL.Interfaces
{
  public interface ICalendar
  {
    ICalendarDay this[DateOnly date] { get; }

    void AddMeeting(IMeeting meeting, DateOnly date);
  }
}