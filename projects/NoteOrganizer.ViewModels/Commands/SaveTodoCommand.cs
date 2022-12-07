using NoteOrganizer.BL.BO;
using NoteOrganizer.BL.Interfaces;
using System.Windows.Input;

namespace NoteOrganizer.ViewModels.Commands
{
  public class SaveTodoCommand : ICommand
  {
    private readonly IAgenda agenda;
    private readonly Action closeCreateTodoWindowAction;
    private readonly ITodoWrapper todoWrapper;

    public SaveTodoCommand(ITodoWrapper todoWrapper, IAgenda agenda, Action closeCreateTodoWindowAction)
    {
      this.todoWrapper = todoWrapper;
      this.agenda = agenda;
      this.closeCreateTodoWindowAction = closeCreateTodoWindowAction;
    }

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
      if (todoWrapper.IsFullDay)
        agenda.AddTodo(new Todo(todoWrapper.TodoTitle, todoWrapper.TodoDescription, DateOnly.FromDateTime(todoWrapper.DueDate), DateTime.Now));
      else
        agenda.AddTodo(new Todo(todoWrapper.TodoTitle, todoWrapper.TodoDescription, DateOnly.FromDateTime(todoWrapper.DueDate), TimeOnly.FromDateTime(todoWrapper.DueTime), DateTime.Now));

      closeCreateTodoWindowAction();
    }

#pragma warning disable CS0067

    public event EventHandler? CanExecuteChanged;

#pragma warning restore CS0067
  }
}