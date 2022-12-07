using NoteOrganizer.BL.BO.Interfaces;

namespace NoteOrganizer.BL.BO
{
  public class Todo : ITodo
  {
    public Todo(string title, string todoDescription, DateOnly dueDate, DateTime createdAt)
    {
      Title = title;
      TodoDescription = todoDescription;
      DueDate = dueDate;
      CreatedAt = createdAt;
      IsFullDay = true;
    }

    public Todo(string title, string todoDescription, DateOnly dueDate, TimeOnly dueTime, DateTime createdAt)
    {
      Title = title;
      TodoDescription = todoDescription;
      DueTime = dueTime;
      DueDate = dueDate;
      CreatedAt = createdAt;
    }

    public DateTime CreatedAt { get; }
    public DateOnly DueDate { get; }
    public TimeOnly DueTime { get; }
    public bool IsFullDay { get; }
    public string Title { get; }
    public string TodoDescription { get; }
  }
}