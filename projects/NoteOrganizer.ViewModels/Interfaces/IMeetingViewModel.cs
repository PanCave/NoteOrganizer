using NoteOrganizer.ViewModels.Wrapper.Interfaces;

namespace NoteOrganizer.ViewModels.Interfaces
{
  public interface IMeetingViewModel
  {
    Color BackgroundColor { get; }
    Color BorderColor { get; }
    int Height { get; }
    string Identifier { get; }
    int Margin { get; }
    Color MouseOverBackgroundColor { get; }
    string Time { get; }
    string Title { get; }
  }
}