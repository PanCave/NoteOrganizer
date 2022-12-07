using NoteOrganizer.ViewModels.Interfaces;
using NoteOrganizer.ViewModels.Wrapper.Interfaces;

namespace NoteOrganizer.ViewModels.Converter
{
  public class TodoViewModel : ITodoViewModel
  {
    public TodoViewModel(string title, string todoDescription, DateOnly dueDate, TimeOnly dueTime, DateTime createdAt, Color backgroundColor, Color mouseOverColor)
    {
      Title = title;
      TodoDescription = todoDescription;
      DueDate = dueDate;
      DueTime = dueTime;
      CreatedAt = createdAt;
      BackgroundColor = backgroundColor;
      MouseOverBackgroundColor = mouseOverColor;
    }

    public Color BackgroundColor { get; }
    public DateTime CreatedAt { get; }
    public DateOnly DueDate { get; }
    public TimeOnly DueTime { get; }
    public Color MouseOverBackgroundColor { get; }
    public string Title { get; }
    public string TodoDescription { get; }
  }
}