namespace NoteOrganizer.ViewModels.Interfaces
{
  public interface ISchedulerWeekViewModel
  {
    ISchedulerDayViewModel FridayViewModel { get; }
    ISchedulerDayViewModel MondayViewModel { get; }
    ISchedulerDayViewModel ThursdayViewModel { get; }
    ISchedulerDayViewModel TuesdayViewModel { get; }
    ISchedulerDayViewModel WednesdayViewModel { get; }
  }
}