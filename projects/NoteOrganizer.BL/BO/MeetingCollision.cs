using NoteOrganizer.BL.BO.Interfaces;

namespace NoteOrganizer.BL.BO
{
  public class MeetingCollision : IMeetingCollision
  {
    public MeetingCollision(TimeOnly startTime, TimeOnly endTime, IMeeting[] involvedMeetings)
    {
      StartTime = startTime;
      EndTime = endTime;
      InvolvedMeetings = involvedMeetings;
    }

    public TimeOnly StartTime { get; }
    public TimeOnly EndTime { get; }
    public IMeeting[] InvolvedMeetings { get; }
  }
}