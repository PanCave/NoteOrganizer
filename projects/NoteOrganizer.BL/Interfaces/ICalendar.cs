using NoteOrganizer.BL.BO;
using NoteOrganizer.BL.BO.Interfaces;

namespace NoteOrganizer.BL.Interfaces
{
  public interface ICalendar
  {
    SupressableObservableCollection<IMeeting> this[DateOnly date] { get; }

    void AddMeeting(IMeeting meeting, DateOnly date);

    void AddMeetingsfromDictionary(Dictionary<DateOnly, List<IMeeting>> meetingsDictionary);
  }
}