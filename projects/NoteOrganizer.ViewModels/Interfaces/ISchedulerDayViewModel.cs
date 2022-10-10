namespace NoteOrganizer.ViewModels.Interfaces
{
  public interface ISchedulerDayViewModel
  {
    List<IMeetingViewModel> MeetingViewModels { get; }
  }
}