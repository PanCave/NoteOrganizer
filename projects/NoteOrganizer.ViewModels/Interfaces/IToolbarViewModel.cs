using System.Windows.Input;

namespace NoteOrganizer.ViewModels.Interfaces
{
  public interface IToolbarViewModel
  {
    ICommand OpenCreateTodoWindowCommand { get; }
  }
}