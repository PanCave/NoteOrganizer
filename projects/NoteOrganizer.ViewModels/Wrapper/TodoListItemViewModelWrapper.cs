using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.BL.Interfaces;
using NoteOrganizer.ViewModels.Converter.Interfaces;
using NoteOrganizer.ViewModels.Interfaces;
using NoteOrganizer.ViewModels.Wrapper.Interfaces;

namespace NoteOrganizer.ViewModels.Wrapper
{
  public class TodoListItemViewModelWrapper : ITodoListItemViewModelWrapper
  {
    private readonly IAgenda agenda;
    private readonly ITodoToTodoViewModelConverter todoToTodoViewModelConverter;

    public TodoListItemViewModelWrapper(IAgenda agenda, ITodoToTodoViewModelConverter todoToTodoViewModelConverter)
    {
      this.agenda = agenda;
      this.todoToTodoViewModelConverter = todoToTodoViewModelConverter;
      TodoListItemViewModels = new List<ITodoListItemViewModel>();
      CreateViewModelsFromTodosCollection();
    }

    private void CreateViewModelsFromTodosCollection()
    {
      foreach (ITodo todo in agenda.Todos)
      {
        TodoListItemViewModels.Add(todoToTodoViewModelConverter.Convert(todo));
      }
    }

    public List<ITodoListItemViewModel> TodoListItemViewModels { get; }
  }
}