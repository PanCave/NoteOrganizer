using NoteOrganizer.BL.Interfaces;
using NoteOrganizer.ViewModels.Interfaces;
using System.Windows.Input;

namespace NoteOrganizer.ViewModels
{
  public class CreateTodoViewModel : ICreateTodoViewModel
  {
    private readonly ITodoWrapper todoWrapper;

    public CreateTodoViewModel(ITodoWrapper todoWrapper, List<TimeOnly> todoDueTimes, ICommand saveTodoCommand)
    {
      this.todoWrapper = todoWrapper;
      TodoDueTimes = todoDueTimes;
      SaveTodoCommand = saveTodoCommand;
    }

    public bool IsFullDay
    {
      get => todoWrapper.IsFullDay;
      set => todoWrapper.IsFullDay = value;
    }

    public ICommand SaveTodoCommand { get; }

    public string TodoDescription
    {
      get => todoWrapper.TodoDescription;
      set => todoWrapper.TodoDescription = value;
    }

    public DateTime TodoDueDate
    {
      get => todoWrapper.DueDate;
      set => todoWrapper.DueDate = value;
    }

    public DateTime TodoDueTime
    {
      get => todoWrapper.DueTime;
      set => todoWrapper.DueTime = value;
    }

    public List<TimeOnly> TodoDueTimes { get; }

    public string TodoTitle
    {
      get => todoWrapper.TodoTitle;
      set => todoWrapper.TodoTitle = value;
    }
  }
}