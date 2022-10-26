using NoteOrganizer.ViewModels.Interfaces;

namespace NoteOrganizer.ViewModels
{
  public class TodoListViewModel : ITodoListViewModel
  {
    public TodoListViewModel(List<ITodoListItemViewModel> todoListElements)
    {
      TodoListElements = todoListElements;
    }

    public List<ITodoListItemViewModel> TodoListElements { get; }
  }
}