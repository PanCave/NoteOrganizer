namespace NoteOrganizer.BL.BO.Interfaces
{
  public interface ICalendarDay
  {
    void AddMeeting(IMeeting meeting);

    DateOnly Date { get; }
    IMeeting[] Meetings { get; }
    IMeetingCollision[] MeetingsCollisions { get; }
  }
}