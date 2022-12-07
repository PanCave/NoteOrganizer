using NoteOrganizer.ViewModels.Interfaces;

namespace NoteOrganizer.ViewModels
{
  public class CombinedViewModel : ICombinedViewModel
  {
    public CombinedViewModel(IToolbarViewModel toolbarViewModel, ITodoListViewModel todoListViewModel, ISchedulerWeekViewModel schedulerWeekViewModel)
    {
      ToolbarViewModel = toolbarViewModel;
      TodoListViewModel = todoListViewModel;
      SchedulerWeekViewModel = schedulerWeekViewModel;
    }

    public ISchedulerWeekViewModel SchedulerWeekViewModel { get; }
    public ITodoListViewModel TodoListViewModel { get; }
    public IToolbarViewModel ToolbarViewModel { get; }
  }
}