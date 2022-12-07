using NoteOrganizer.ViewModels.Interfaces;
using System.Windows.Input;

namespace NoteOrganizer.ViewModels
{
  public class ToolbarViewModel : IToolbarViewModel
  {
    public ToolbarViewModel(ICommand openCreateTodoWindowCommand)
    {
      OpenCreateTodoWindowCommand = openCreateTodoWindowCommand;
    }

    public ICommand OpenCreateTodoWindowCommand { get; }
  }
}