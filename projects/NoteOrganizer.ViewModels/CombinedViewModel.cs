using NoteOrganizer.ViewModels.Interfaces;

namespace NoteOrganizer.ViewModels
{
  public class CombinedViewModel : ICombinedViewModel
  {
    public CombinedViewModel(ITodoListViewModel todoListViewModel, ISchedulerWeekViewModel schedulerWeekViewModel)
    {
      TodoListViewModel = todoListViewModel;
      SchedulerWeekViewModel = schedulerWeekViewModel;
    }

    public ISchedulerWeekViewModel SchedulerWeekViewModel { get; }
    public ITodoListViewModel TodoListViewModel { get; }
  }
}