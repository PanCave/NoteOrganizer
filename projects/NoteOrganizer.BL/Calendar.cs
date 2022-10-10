using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.BL.Interfaces;
using System.Collections.ObjectModel;

namespace NoteOrganizer.BL
{
  public class Calendar : ICalendar
  {
    private readonly Dictionary<DateOnly, ObservableCollection<IMeeting>> meetingsDictionary;

    public Calendar()
    {
      meetingsDictionary = new Dictionary<DateOnly, ObservableCollection<IMeeting>>();
    }

    public void AddMeeting(IMeeting meeting, DateOnly date)
    {
      if (!meetingsDictionary.ContainsKey(date))
        meetingsDictionary[date] = new ObservableCollection<IMeeting>();
      meetingsDictionary[date].Add(meeting);
    }

    public ObservableCollection<IMeeting> this[DateOnly date] => meetingsDictionary[date];
  }
}