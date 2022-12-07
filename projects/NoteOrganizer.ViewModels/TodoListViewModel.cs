using NoteOrganizer.BL.BO;
using NoteOrganizer.ViewModels.Interfaces;
using NoteOrganizer.ViewModels.Wrapper.Interfaces;
using System.ComponentModel;

namespace NoteOrganizer.ViewModels
{
  public class TodoListViewModel : ITodoListViewModel, INotifyPropertyChanged
  {
    private readonly ITodoListItemViewModelWrapper todoListItemViewModelWrapper;

    public TodoListViewModel(ITodoListItemViewModelWrapper todoListItemViewModelWrapper)
    {
      this.todoListItemViewModelWrapper = todoListItemViewModelWrapper;
      todoListItemViewModelWrapper.PropertyChanged += TodoListItemViewModelWrapper_PropertyChanged;
    }

    private void TodoListItemViewModelWrapper_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == null || !e.PropertyName.Equals(nameof(ITodoListItemViewModelWrapper.TodoListItemViewModels)))
        return;

      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TodoListElements)));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public SupressableObservableCollection<ITodoListItemViewModel> TodoListElements => todoListItemViewModelWrapper.TodoListItemViewModels;
  }
}