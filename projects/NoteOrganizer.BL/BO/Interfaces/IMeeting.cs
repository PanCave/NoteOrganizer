namespace NoteOrganizer.BL.BO.Interfaces
{
  public interface IMeeting
  {
    TimeSpan Duration { get; }
    TimeOnly EndTime { get; }
    string Identifier { get; }
    string Notes { get; }
    TimeOnly StartTime { get; }
    string Title { get; }
  }
}