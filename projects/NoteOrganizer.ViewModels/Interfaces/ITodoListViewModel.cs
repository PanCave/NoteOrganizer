using NoteOrganizer.BL.BO;

namespace NoteOrganizer.ViewModels.Interfaces
{
  public interface ITodoListViewModel
  {
    SupressableObservableCollection<ITodoListItemViewModel> TodoListElements { get; }
  }
}