using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.BL.Interfaces;
using NoteOrganizer.ViewModels.Converter;
using NoteOrganizer.ViewModels.Converter.Interfaces;
using NoteOrganizer.ViewModels.Interfaces;
using NoteOrganizer.ViewModels.Wrapper.Interfaces;

namespace NoteOrganizer.ViewModels.Wrapper
{
  public class TodoListItemViewModelWrapper : ITodoListItemViewModelWrapper
  {
    private readonly IAgenda agenda;
    private readonly ITodoToTodoViewModelConverter todoToTodoViewModelConverter;
    private readonly IDateOnlyToToTimeCategoryConverter dateOnlyToToTimeCategoryConverter;

    public TodoListItemViewModelWrapper(IAgenda agenda, ITodoToTodoViewModelConverter todoToTodoViewModelConverter, IDateOnlyToToTimeCategoryConverter dateOnlyToToTimeCategoryConverter)
    {
      this.agenda = agenda;
      this.todoToTodoViewModelConverter = todoToTodoViewModelConverter;
      this.dateOnlyToToTimeCategoryConverter = dateOnlyToToTimeCategoryConverter;
      TodoListItemViewModels = new List<ITodoListItemViewModel>();
      CreateViewModelsFromTodosCollection();
    }

    public List<ITodoListItemViewModel> TodoListItemViewModels { get; }

    private void CreateViewModelsFromTodosCollection()
    {
      if (agenda.Todos.Length == 0)
        return;

      TimeCategory previousTimeCategory = dateOnlyToToTimeCategoryConverter.ConvertToTimeCategory(agenda.Todos[0].DueDate);
      foreach (ITodo todo in agenda.Todos)
      {
        TimeCategory currentTimeCategory = dateOnlyToToTimeCategoryConverter.ConvertToTimeCategory(todo.DueDate);

        if (currentTimeCategory != previousTimeCategory)
          TodoListItemViewModels.Add(new TodoListSeparatorViewModel(currentTimeCategory));
        TodoListItemViewModels.Add(todoToTodoViewModelConverter.Convert(todo));

        previousTimeCategory = currentTimeCategory;
      }
    }

    private TimeCategory GetTimeCategory(ITodo todo)
    {
      return TimeCategory.Later;
    }
  }
}