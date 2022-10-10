using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.ViewModels.Interfaces;
using NoteOrganizer.ViewModels.Wrapper.Interfaces;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace NoteOrganizer.ViewModels.Wrapper
{
  public class MeetingViewModelWrapper : IMeetingViewModelWrapper
  {
    private readonly Array colorValues;
    private readonly ObservableCollection<IMeeting> meetings;
    private readonly Random random;

    public MeetingViewModelWrapper(ObservableCollection<IMeeting> meetings)
    {
      this.meetings = meetings;
      meetings.CollectionChanged += Meetings_CollectionChanged;
      MeetingViewModels = new List<IMeetingViewModel>();
      random = new Random();
      colorValues = Enum.GetValues(typeof(Color));
      CreateViewModelsFromMeetingsCollection();
    }

    private IMeetingViewModel ConvertToMeetingViewModel(IMeeting meeting, TimeOnly lastEndTime)
    {
      return new MeetingViewModel(
            meeting.Title,
            $"{meeting.StartTime:HH':'mm} - {meeting.EndTime:HH':'mm' Uhr'}",
            meeting.Identifier,
            Convert.ToInt32(Math.Floor(meeting.Duration.TotalMinutes)) * 3,
            Convert.ToInt32(Math.Floor((meeting.StartTime - lastEndTime).TotalMinutes)) * 3,
            (Color)colorValues.GetValue(random.Next(colorValues.Length)),
            (Color)colorValues.GetValue(random.Next(colorValues.Length)),
            (Color)colorValues.GetValue(random.Next(colorValues.Length)));
    }

    private void CreateViewModelsFromMeetingsCollection()
    {
      TimeOnly lastEndTime = meetings.First().StartTime;
      foreach (IMeeting meeting in meetings)
      {
        MeetingViewModels.Add(ConvertToMeetingViewModel(meeting, lastEndTime));
        lastEndTime = meeting.EndTime;
      }
    }

    private void InsertNewMeetingViewModels(IList? newItems)
    {
      throw new NotImplementedException();
    }

    private void Meetings_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
      switch (e.Action)
      {
        case NotifyCollectionChangedAction.Add:
          InsertNewMeetingViewModels(e.NewItems);
          break;

        case NotifyCollectionChangedAction.Remove:
          break;

        case NotifyCollectionChangedAction.Replace:
          break;

        case NotifyCollectionChangedAction.Move:
          break;

        case NotifyCollectionChangedAction.Reset:
          break;

        default:
          break;
      }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public List<IMeetingViewModel> MeetingViewModels { get; }
  }
}