namespace NoteOrganizer.BL.BO.Interfaces
{
  public interface ITodo
  {
    DateTime CreatedAt { get; }
    DateOnly DueDate { get; }
    TimeOnly DueTime { get; }
    string Title { get; }
    string TodoText { get; }
  }
}