using NoteOrganizer.ViewModels.Interfaces;

namespace NoteOrganizer.ViewModels.Wrapper.Interfaces
{
  public interface ITodoListItemViewModelWrapper
  {
    List<ITodoListItemViewModel> TodoListItemViewModels { get; }
  }
}