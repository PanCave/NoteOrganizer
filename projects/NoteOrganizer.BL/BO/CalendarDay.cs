using NoteOrganizer.BL.BO.Interfaces;

namespace NoteOrganizer.BL.BO
{
  public class CalendarDay : ICalendarDay
  {
    private List<IMeeting> meetings;
    private List<IMeetingCollision> meetingCollisions;
    private IMeeting[] meetingsArray;
    private IMeetingCollision[] meetingsCollisionsArray;

    public CalendarDay(DateOnly date)
    {
      meetingsArray = new Meeting[0];
      meetingsCollisionsArray = new MeetingCollision[0];
      meetings = new List<IMeeting>();
      meetingCollisions = new List<IMeetingCollision>();
      Date = date;
    }

    public IMeeting[] Meetings => meetingsArray;
    public IMeetingCollision[] MeetingsCollisions => meetingsCollisionsArray;
    public DateOnly Date { get; }

    public void AddMeeting(IMeeting newMeeting)
    {
      int i = 0;
      bool inserted = false;
      foreach (IMeeting meeting in meetings)
      {
        CheckForCollision(newMeeting, meeting);
        if (meeting.StartTime >= newMeeting.StartTime)
        {
          meetings.Insert(i, newMeeting);
          inserted = true;
          break;
        }
        i++;
      }
      if (!inserted)
        meetings.Add(newMeeting);

      meetingsArray = meetings.ToArray();
      meetingsCollisionsArray = meetingCollisions.ToArray();
    }

    private void CheckForCollision(IMeeting meeting, IMeeting other)
    {
      TimeOnly startTime;
      TimeOnly endTime;
      bool collissionDetected = false;
      if (other.StartTime < meeting.StartTime && other.EndTime < meeting.EndTime)
      {
        startTime = meeting.StartTime;
        endTime = other.EndTime;
        collissionDetected = true;
      }
      else if (other.StartTime < meeting.StartTime && other.EndTime > meeting.EndTime)
      {
        startTime = meeting.StartTime;
        endTime = meeting.EndTime;
        collissionDetected = true;
      }
      else if (other.StartTime > meeting.StartTime && other.EndTime > meeting.EndTime)
      {
        startTime = other.StartTime;
        endTime = meeting.EndTime;
        collissionDetected = true;
      }
      else if (other.StartTime > meeting.StartTime && other.EndTime < meeting.EndTime)
      {
        startTime = other.StartTime;
        endTime = other.EndTime;
        collissionDetected = true;
      }
      if (!collissionDetected)
        return;
      meetingCollisions.Add(new MeetingCollision(startTime, endTime, new[] { meeting, other }));
    }
  }
}