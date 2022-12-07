namespace NoteOrganizer.BL.Interfaces
{
  public interface ITodoWrapper
  {
    DateTime DueDate { get; set; }
    DateTime DueTime { get; set; }
    bool IsFullDay { get; set; }
    string TodoDescription { get; set; }
    string TodoTitle { get; set; }
  }
}