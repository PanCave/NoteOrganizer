namespace NoteOrganizer.ViewModels.Interfaces
{
  public interface ICombinedViewModel
  {
    ISchedulerWeekViewModel SchedulerWeekViewModel { get; }
    ITodoListViewModel TodoListViewModel { get; }
  }
}