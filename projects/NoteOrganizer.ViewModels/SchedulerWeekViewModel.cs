using NoteOrganizer.ViewModels.Interfaces;

namespace NoteOrganizer.ViewModels
{
  public class SchedulerWeekViewModel : ISchedulerWeekViewModel
  {
    public SchedulerWeekViewModel(
      ISchedulerDayHeaderViewModel mondayHeaderViewModel,
      ISchedulerDayHeaderViewModel tuesdayHeaderViewModel,
      ISchedulerDayHeaderViewModel wednesdayHeaderViewModel,
      ISchedulerDayHeaderViewModel thursdayHeaderViewModel,
      ISchedulerDayHeaderViewModel fridayHeaderViewModel,
      ISchedulerDayViewModel mondayViewModel,
      ISchedulerDayViewModel tuesdayViewModel,
      ISchedulerDayViewModel wednesdayViewModel,
      ISchedulerDayViewModel thursdayViewModel,
      ISchedulerDayViewModel fridayViewModel)
    {
      MondayHeaderViewModel = mondayHeaderViewModel;
      TuesdayHeaderViewModel = tuesdayHeaderViewModel;
      WednesdayHeaderViewModel = wednesdayHeaderViewModel;
      ThursdayHeaderViewModel = thursdayHeaderViewModel;
      FridayHeaderViewModel = fridayHeaderViewModel;
      MondayViewModel = mondayViewModel;
      TuesdayViewModel = tuesdayViewModel;
      WednesdayViewModel = wednesdayViewModel;
      ThursdayViewModel = thursdayViewModel;
      FridayViewModel = fridayViewModel;
    }

    public ISchedulerDayHeaderViewModel FridayHeaderViewModel { get; }
    public ISchedulerDayViewModel FridayViewModel { get; }
    public ISchedulerDayHeaderViewModel MondayHeaderViewModel { get; }
    public ISchedulerDayViewModel MondayViewModel { get; }
    public ISchedulerDayHeaderViewModel ThursdayHeaderViewModel { get; }
    public ISchedulerDayViewModel ThursdayViewModel { get; }
    public ISchedulerDayHeaderViewModel TuesdayHeaderViewModel { get; }
    public ISchedulerDayViewModel TuesdayViewModel { get; }
    public ISchedulerDayHeaderViewModel WednesdayHeaderViewModel { get; }
    public ISchedulerDayViewModel WednesdayViewModel { get; }
  }
}