using NoteOrganizer.BL.Interfaces;

namespace NoteOrganizer.Persistence.Interfaces
{
  public interface IMeetingsLoader
  {
    void LoadMeetings(DateOnly startDate, DateOnly endDate, ICalendar calendar);
  }
}