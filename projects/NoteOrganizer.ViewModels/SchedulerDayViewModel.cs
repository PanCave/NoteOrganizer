using NoteOrganizer.ViewModels.Interfaces;
using NoteOrganizer.ViewModels.Wrapper.Interfaces;

namespace NoteOrganizer.ViewModels
{
  public class SchedulerDayViewModel : ISchedulerDayViewModel
  {
    private readonly IMeetingViewModelWrapper meetingViewModelWrapper;

    public SchedulerDayViewModel(IMeetingViewModelWrapper meetingViewModelWrapper)
    {
      this.meetingViewModelWrapper = meetingViewModelWrapper;
    }

    public List<IMeetingViewModel> MeetingViewModels => meetingViewModelWrapper.MeetingViewModels;
  }
}