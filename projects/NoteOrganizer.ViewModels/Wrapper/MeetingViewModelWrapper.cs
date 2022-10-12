using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.ViewModels.Interfaces;
using NoteOrganizer.ViewModels.Wrapper.Interfaces;
using System.ComponentModel;

namespace NoteOrganizer.ViewModels.Wrapper
{
  public class MeetingViewModelWrapper : IMeetingViewModelWrapper
  {
    private readonly Array colorValues;
    private readonly Random random;
    private readonly ICalendarDay calendarDay;

    public MeetingViewModelWrapper(ICalendarDay calendarDay)
    {
      MeetingViewModels = new List<IMeetingViewModel>();
      random = new Random();
      colorValues = Enum.GetValues(typeof(Color));
      this.calendarDay = calendarDay;
      CreateViewModelsFromMeetingsCollection();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public List<IMeetingViewModel> MeetingViewModels { get; }

    private IMeetingViewModel ConvertToMeetingViewModel(IMeeting meeting, TimeOnly lastEndTime)
    {
#pragma warning disable CS8605 // Unboxing eines möglichen NULL-Werts.
      return new MeetingViewModel(
            meeting.Title,
            $"{meeting.StartTime:HH':'mm} - {meeting.EndTime:HH':'mm' Uhr'}",
            meeting.Identifier,
            Convert.ToInt32(Math.Floor(meeting.Duration.TotalMinutes)) * 3,
            Convert.ToInt32(Math.Floor((meeting.StartTime - lastEndTime).TotalMinutes)) * 3,
            (Color)colorValues.GetValue(random.Next(colorValues.Length)),
            (Color)colorValues.GetValue(random.Next(colorValues.Length)),
            (Color)colorValues.GetValue(random.Next(colorValues.Length)));
#pragma warning restore CS8605 // Unboxing eines möglichen NULL-Werts.
    }

    private void CreateViewModelsFromMeetingsCollection()
    {
      TimeOnly lastEndTime = TimeOnly.MinValue;
      foreach (IMeeting meeting in calendarDay.Meetings)
      {
        MeetingViewModels.Add(ConvertToMeetingViewModel(meeting, lastEndTime));
        lastEndTime = meeting.EndTime;
      }
    }
  }
}