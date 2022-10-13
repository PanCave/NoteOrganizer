using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.ViewModels.Converter.Interfaces;
using NoteOrganizer.ViewModels.Interfaces;
using NoteOrganizer.ViewModels.Wrapper.Interfaces;

namespace NoteOrganizer.ViewModels.Converter
{
  public class MeetingToMeetingViewModelConverter : IMeetingToMeetingViewModelConverter
  {
    private readonly Array colorValues;
    private readonly Random random;

    public MeetingToMeetingViewModelConverter()
    {
      random = new Random();
      colorValues = Enum.GetValues(typeof(Color));
    }

    public IMeetingViewModel Convert(IMeeting meeting, TimeOnly lastEndTime)
    {
      string timeString = $"{meeting.StartTime:H':'mm} - {meeting.EndTime:H':'mm' Uhr'}";
      int height = System.Convert.ToInt32(Math.Floor(meeting.Duration.TotalMinutes)) * 3;

      int margin;
      if (lastEndTime > meeting.StartTime)
        margin = System.Convert.ToInt32(-Math.Floor((lastEndTime - meeting.StartTime).TotalMinutes)) * 3;
      else
        margin = System.Convert.ToInt32(Math.Floor((meeting.StartTime - lastEndTime).TotalMinutes)) * 3;

      return new MeetingViewModel(
            meeting.Title,
            timeString,
            meeting.Identifier,
            height,
            margin,
            (Color)colorValues.GetValue(random.Next(colorValues.Length)),
            (Color)colorValues.GetValue(random.Next(colorValues.Length)),
            (Color)colorValues.GetValue(random.Next(colorValues.Length)));
    }
  }
}