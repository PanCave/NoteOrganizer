using NoteOrganizer.ViewModels.Interfaces;
using NoteOrganizer.ViewModels.Wrapper.Interfaces;

namespace NoteOrganizer.ViewModels
{
  public class MeetingViewModel : IMeetingViewModel
  {
    public MeetingViewModel(string title, string time, string identifier, int height, int margin, Color borderColor, Color backgroundColor, Color mouseOverBackgroundColor)
    {
      Title = title;
      Time = time;
      Identifier = identifier;
      Height = height;
      Margin = margin;
      BorderColor = borderColor;
      BackgroundColor = backgroundColor;
      MouseOverBackgroundColor = mouseOverBackgroundColor;
    }

    public Color BackgroundColor { get; }
    public Color BorderColor { get; }
    public int Height { get; }
    public string Identifier { get; }
    public int Margin { get; }
    public Color MouseOverBackgroundColor { get; }
    public string Time { get; }
    public string Title { get; }
  }
}