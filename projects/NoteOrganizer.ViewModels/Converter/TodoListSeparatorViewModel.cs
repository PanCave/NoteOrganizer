using NoteOrganizer.ViewModels.Interfaces;

namespace NoteOrganizer.ViewModels.Converter
{
  public class TodoListSeparatorViewModel : ITodoListItemViewModel
  {
    public TodoListSeparatorViewModel(string title)
    {
      Title = title;
    }

    public string Title { get; }
  }
}