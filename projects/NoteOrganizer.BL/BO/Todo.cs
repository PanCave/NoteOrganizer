using NoteOrganizer.BL.BO.Interfaces;

namespace NoteOrganizer.BL.BO
{
  public class Todo : ITodo
  {
    public Todo(string title, string todoText, DateOnly dueDate, TimeOnly dueTime, DateTime createdAt)
    {
      Title = title;
      TodoText = todoText;
      DueTime = dueTime;
      DueDate = dueDate;
      CreatedAt = createdAt;
    }

    public DateTime CreatedAt { get; }
    public DateOnly DueDate { get; }
    public TimeOnly DueTime { get; }
    public string Title { get; }
    public string TodoText { get; }
  }
}