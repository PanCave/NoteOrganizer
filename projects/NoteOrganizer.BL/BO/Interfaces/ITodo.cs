namespace NoteOrganizer.BL.BO.Interfaces
{
  public interface ITodo
  {
    DateTime CreatedAt { get; }
    DateOnly DueDate { get; }
    TimeOnly DueTime { get; }
    bool IsFullDay { get; }
    string Title { get; }
    string TodoDescription { get; }
  }
}