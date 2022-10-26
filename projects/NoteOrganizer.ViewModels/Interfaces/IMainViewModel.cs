namespace NoteOrganizer.ViewModels.Interfaces
{
  public interface IMainViewModel
  {
    ISchedulerWeekViewModel SchedulerWeekViewModel { get; }
    ITodoListViewModel TodoListViewModel { get; }
  }
}