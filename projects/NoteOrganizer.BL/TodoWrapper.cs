using NoteOrganizer.BL.Interfaces;

namespace NoteOrganizer.BL
{
  public class TodoWrapper : ITodoWrapper
  {
    public TodoWrapper()
    {
      TodoDescription = string.Empty;
      TodoTitle = string.Empty;
      IsFullDay = true;
      DueDate = DateTime.Today;
      DueTime = DateTime.Today;
    }

    public DateTime DueDate { get; set; }
    public DateTime DueTime { get; set; }
    public bool IsFullDay { get; set; }
    public string TodoDescription { get; set; }
    public string TodoTitle { get; set; }
  }
}