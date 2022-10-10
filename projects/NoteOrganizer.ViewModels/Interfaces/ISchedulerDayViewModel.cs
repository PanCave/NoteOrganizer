namespace NoteOrganizer.ViewModels.Interfaces
{
  public interface ISchedulerDayViewModel
  {
    string DayOfMonth { get; }
    List<IMeetingViewModel> MeetingViewModels { get; }
    string Weekday { get; }
  }
}