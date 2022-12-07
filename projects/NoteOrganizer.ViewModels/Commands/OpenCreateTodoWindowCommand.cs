using System.Windows.Input;

namespace NoteOrganizer.ViewModels.Commands
{
  public class OpenCreateTodoWindowCommand : ICommand
  {
    private readonly Action openCreateTodoWindowAction;

    public OpenCreateTodoWindowCommand(Action openCreateTodoWindowAction)
    {
      this.openCreateTodoWindowAction = openCreateTodoWindowAction;
    }

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
      openCreateTodoWindowAction();
    }

#pragma warning disable CS0067

    public event EventHandler? CanExecuteChanged;

#pragma warning restore CS0067
  }
}