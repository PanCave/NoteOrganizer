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
    private readonly IDateOnlyToToTimeCategoryConverter dateOnlyToToTimeCategoryConverter;
    private readonly ITodoToTodoViewModelConverter todoToTodoViewModelConverter;

    public TodoListItemViewModelWrapper(IAgenda agenda, ITodoToTodoViewModelConverter todoToTodoViewModelConverter, IDateOnlyToToTimeCategoryConverter dateOnlyToToTimeCategoryConverter)
    {
      this.agenda = agenda;
      this.todoToTodoViewModelConverter = todoToTodoViewModelConverter;
      this.dateOnlyToToTimeCategoryConverter = dateOnlyToToTimeCategoryConverter;
      TodoListItemViewModels = new List<ITodoListItemViewModel>();
      CreateViewModelsFromTodosCollection();
    }

    private void CreateViewModelsFromTodosCollection()
    {
      if (agenda.Todos.Length == 0)
        return;

      TimeCategory previousTimeCategory = dateOnlyToToTimeCategoryConverter.ConvertToTimeCategory(agenda.Todos[0].DueDate);
      if (previousTimeCategory == TimeCategory.Overdue)
        TodoListItemViewModels.Add(new TodoListSeparatorViewModel(TimeCategory.Overdue));
      foreach (ITodo todo in agenda.Todos)
      {
        TimeCategory currentTimeCategory = dateOnlyToToTimeCategoryConverter.ConvertToTimeCategory(todo.DueDate);

        if (currentTimeCategory != previousTimeCategory)
          TodoListItemViewModels.Add(new TodoListSeparatorViewModel(currentTimeCategory));
        TodoListItemViewModels.Add(todoToTodoViewModelConverter.Convert(todo));

        previousTimeCategory = currentTimeCategory;
      }
    }

    public List<ITodoListItemViewModel> TodoListItemViewModels { get; }
  }
}