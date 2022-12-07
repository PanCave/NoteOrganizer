using NoteOrganizer.BL.BO;
using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.BL.Interfaces;
using NoteOrganizer.ViewModels.Converter;
using NoteOrganizer.ViewModels.Converter.Interfaces;
using NoteOrganizer.ViewModels.Interfaces;
using NoteOrganizer.ViewModels.Wrapper.Interfaces;
using System.ComponentModel;

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
      agenda.PropertyChanged += Agenda_PropertyChanged;
      this.todoToTodoViewModelConverter = todoToTodoViewModelConverter;
      this.dateOnlyToToTimeCategoryConverter = dateOnlyToToTimeCategoryConverter;
      TodoListItemViewModels = new SupressableObservableCollection<ITodoListItemViewModel>();
      CreateViewModelsFromTodosCollection();
    }

    private void Agenda_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == null || !e.PropertyName.Equals(nameof(IAgenda.Todos)))
        return;

      CreateViewModelsFromTodosCollection();
    }

    private void CreateViewModelsFromTodosCollection()
    {
      TodoListItemViewModels.Clear();

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

      TodoListItemViewModels.TriggerCollectionChanged();
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TodoListItemViewModels)));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public SupressableObservableCollection<ITodoListItemViewModel> TodoListItemViewModels { get; }
  }
}