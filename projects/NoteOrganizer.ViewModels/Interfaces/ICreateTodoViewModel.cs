using System.Windows.Input;

namespace NoteOrganizer.ViewModels.Interfaces
{
  public interface ICreateTodoViewModel
  {
    bool IsFullDay { get; set; }
    ICommand SaveTodoCommand { get; }
    string TodoDescription { get; set; }
    DateTime TodoDueDate { get; set; }
    DateTime TodoDueTime { get; set; }
    List<TimeOnly> TodoDueTimes { get; }
    string TodoTitle { get; set; }
  }
}