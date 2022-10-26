using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.ViewModels.Converter.Interfaces;
using NoteOrganizer.ViewModels.Interfaces;
using NoteOrganizer.ViewModels.Wrapper.Interfaces;

namespace NoteOrganizer.ViewModels.Converter
{
  public class TodoToTodoViewModelConverter : ITodoToTodoViewModelConverter
  {
    private readonly Array colorValues;
    private readonly Random random;

    public TodoToTodoViewModelConverter()
    {
      random = new Random();
      colorValues = Enum.GetValues(typeof(Color));
    }

    public ITodoViewModel Convert(ITodo todo)
    {
#pragma warning disable CS8605 // Unboxing eines möglichen NULL-Werts.
      return new TodoViewModel(
        todo.Title,
        todo.TodoText,
        todo.DueDate,
        todo.DueTime,
        todo.CreatedAt,
        (Color)colorValues.GetValue(random.Next(colorValues.Length)),
        (Color)colorValues.GetValue(random.Next(colorValues.Length)));
#pragma warning restore CS8605 // Unboxing eines möglichen NULL-Werts.
    }
  }
}