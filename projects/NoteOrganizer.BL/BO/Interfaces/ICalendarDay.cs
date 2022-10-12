namespace NoteOrganizer.BL.BO.Interfaces
{
  public interface ICalendarDay
  {
    IMeeting[] Meetings { get; }

    IMeetingCollision[] MeetingsCollisions { get; }

    DateOnly Date { get; }

    void AddMeeting(IMeeting meeting);
  }
}