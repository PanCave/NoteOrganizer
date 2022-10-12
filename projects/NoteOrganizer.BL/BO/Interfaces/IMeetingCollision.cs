namespace NoteOrganizer.BL.BO.Interfaces
{
  public interface IMeetingCollision
  {
    TimeOnly StartTime { get; }
    TimeOnly EndTime { get; }
    IMeeting[] InvolvedMeetings { get; }
  }
}