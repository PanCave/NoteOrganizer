using NoteOrganizer.ViewModels.Interfaces;

namespace NoteOrganizer.ViewModels
{
  public class SchedulerWeekViewModel : ISchedulerWeekViewModel
  {
    public SchedulerWeekViewModel(
      ISchedulerDayViewModel mondayViewModel,
      ISchedulerDayViewModel tuesdayViewModel,
      ISchedulerDayViewModel wednesdayViewModel,
      ISchedulerDayViewModel thursdayViewModel,
      ISchedulerDayViewModel fridayViewModel)
    {
      MondayViewModel = mondayViewModel;
      TuesdayViewModel = tuesdayViewModel;
      WednesdayViewModel = wednesdayViewModel;
      ThursdayViewModel = thursdayViewModel;
      FridayViewModel = fridayViewModel;
    }

    public ISchedulerDayViewModel FridayViewModel { get; }
    public ISchedulerDayViewModel MondayViewModel { get; }
    public ISchedulerDayViewModel ThursdayViewModel { get; }
    public ISchedulerDayViewModel TuesdayViewModel { get; }
    public ISchedulerDayViewModel WednesdayViewModel { get; }
  }
}