using NoteOrganizer.BL.BO.Interfaces;

namespace NoteOrganizer.BL.BO
{
  public class Meeting : IMeeting
  {
    public Meeting(string title, TimeOnly startTime, TimeOnly endTime, string identifier, string notes)
    {
      Title = title;
      StartTime = startTime;
      EndTime = endTime;
      Identifier = identifier;
      Notes = notes;
      Duration = EndTime - StartTime;
    }

    public TimeSpan Duration { get; }
    public TimeOnly EndTime { get; }
    public string Identifier { get; }
    public string Notes { get; }
    public TimeOnly StartTime { get; }
    public string Title { get; }
  }
}