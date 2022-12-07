using NoteOrganizer.BL.BO;
using NoteOrganizer.ViewModels.Interfaces;
using System.ComponentModel;

namespace NoteOrganizer.ViewModels.Wrapper.Interfaces
{
  public interface ITodoListItemViewModelWrapper : INotifyPropertyChanged
  {
    SupressableObservableCollection<ITodoListItemViewModel> TodoListItemViewModels { get; }
  }
}