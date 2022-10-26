namespace NoteOrganizer.ViewModels.Interfaces
{
  public interface ITodoListViewModel
  {
    List<ITodoListItemViewModel> TodoListElements { get; }
  }
}