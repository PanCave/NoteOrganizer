using NoteOrganizer.ViewModels.Wrapper.Interfaces;

namespace NoteOrganizer.ViewModels.Interfaces
{
  public interface ITodoViewModel : ITodoListItemViewModel
  {
    Color BackgroundColor { get; }
    DateTime CreatedAt { get; }
    DateOnly DueDate { get; }
    TimeOnly DueTime { get; }
    Color MouseOverBackgroundColor { get; }
    string TodoDescription { get; }
  }
}