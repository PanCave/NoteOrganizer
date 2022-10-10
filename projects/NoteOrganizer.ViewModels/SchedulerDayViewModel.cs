using NoteOrganizer.ViewModels.Interfaces;
using NoteOrganizer.ViewModels.Wrapper.Interfaces;
using System.ComponentModel;

namespace NoteOrganizer.ViewModels
{
  public class SchedulerDayViewModel : ISchedulerDayViewModel, INotifyPropertyChanged
  {
    private readonly IMeetingViewModelWrapper meetingViewModelWrapper;

    public SchedulerDayViewModel(string dayOfMonth, string weekday, IMeetingViewModelWrapper meetingViewModelWrapper)
    {
      DayOfMonth = dayOfMonth;
      Weekday = weekday;
      this.meetingViewModelWrapper = meetingViewModelWrapper;
      meetingViewModelWrapper.PropertyChanged += MeetingViewModelWrapper_PropertyChanged;
    }

    private void MeetingViewModelWrapper_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MeetingViewModels)));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public string DayOfMonth { get; }
    public List<IMeetingViewModel> MeetingViewModels => meetingViewModelWrapper.MeetingViewModels;
    public string Weekday { get; }
  }
}