using NoteOrganizer.ViewModels.Interfaces;

namespace NoteOrganizer.ViewModels
{
  public class MainViewModel : IMainViewModel
  {
    public MainViewModel(ISchedulerWeekViewModel schedulerWeekViewModel)
    {
      SchedulerWeekViewModel = schedulerWeekViewModel;
    }

    public ISchedulerWeekViewModel SchedulerWeekViewModel { get; }
  }
}