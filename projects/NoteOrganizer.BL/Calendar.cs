using NoteOrganizer.BL.BO;
using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.BL.Interfaces;

namespace NoteOrganizer.BL
{
  public class Calendar : ICalendar
  {
    private readonly Dictionary<DateOnly, SupressableObservableCollection<IMeeting>> meetingsDictionary;

    public Calendar()
    {
      meetingsDictionary = new Dictionary<DateOnly, SupressableObservableCollection<IMeeting>>();
    }

    public SupressableObservableCollection<IMeeting> this[DateOnly date] => meetingsDictionary[date];

    public void AddMeeting(IMeeting meeting, DateOnly date)
    {
      if (!meetingsDictionary.ContainsKey(date))
        meetingsDictionary[date] = new SupressableObservableCollection<IMeeting>();
      meetingsDictionary[date].Add(meeting);
    }

    public void AddMeetingsfromDictionary(Dictionary<DateOnly, List<IMeeting>> meetingsDictionary)
    {
      foreach (KeyValuePair<DateOnly, List<IMeeting>> keyValuePair in meetingsDictionary)
      {
        if (!this.meetingsDictionary.ContainsKey(keyValuePair.Key))
          this.meetingsDictionary[keyValuePair.Key] = new SupressableObservableCollection<IMeeting>(keyValuePair.Value);
        else
          foreach (IMeeting meeting in keyValuePair.Value)
          {
            this.meetingsDictionary[keyValuePair.Key].SupressNotification = true;
            this.meetingsDictionary[keyValuePair.Key].Add(meeting);
            this.meetingsDictionary[keyValuePair.Key].SupressNotification = false;
          }
      }
    }
  }
}