using NoteOrganizer.BL.BO.Interfaces;

namespace NoteOrganizer.Persistence.Interfaces
{
  public interface IMeetingsLoader
  {
    Dictionary<DateOnly, List<IMeeting>> LoadMeetings(DateOnly startDate, DateOnly endDate);
  }
}