using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.ViewModels.Converter.Interfaces;
using NoteOrganizer.ViewModels.Interfaces;
using NoteOrganizer.ViewModels.Wrapper.Interfaces;
using System.ComponentModel;

namespace NoteOrganizer.ViewModels.Wrapper
{
  public class MeetingViewModelWrapper : IMeetingViewModelWrapper
  {
    private readonly ICalendarDay calendarDay;
    private readonly IMeetingToMeetingViewModelConverter meetingToMeetingViewModelConverter;

    public MeetingViewModelWrapper(ICalendarDay calendarDay, IMeetingToMeetingViewModelConverter meetingToMeetingViewModelConverter)
    {
      this.calendarDay = calendarDay;
      this.meetingToMeetingViewModelConverter = meetingToMeetingViewModelConverter;
      MeetingViewModels = new List<IMeetingViewModel>();
      CreateViewModelsFromMeetingsCollection();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public List<IMeetingViewModel> MeetingViewModels { get; }

    private void CreateViewModelsFromMeetingsCollection()
    {
      TimeOnly lastEndTime = TimeOnly.MinValue;
      foreach (IMeeting meeting in calendarDay.Meetings)
      {
        MeetingViewModels.Add(meetingToMeetingViewModelConverter.Convert(meeting, lastEndTime));
        lastEndTime = meeting.EndTime;
      }
    }
  }
}