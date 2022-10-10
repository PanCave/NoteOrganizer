using NoteOrganizer.BL.BO;
using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.ViewModels;
using NoteOrganizer.ViewModels.Interfaces;
using NoteOrganizer.ViewModels.Wrapper;
using NoteOrganizer.ViewModels.Wrapper.Interfaces;
using System.Collections.ObjectModel;

namespace NoteOrganizer.AL
{
  public class AppLogic
  {
    public AppLogic()
    {
      ObservableCollection<IMeeting> mondayMeetings = new ObservableCollection<IMeeting>();
      ObservableCollection<IMeeting> tuesdayMeetings = new ObservableCollection<IMeeting>();
      ObservableCollection<IMeeting> wednesdayMeetings = new ObservableCollection<IMeeting>();
      ObservableCollection<IMeeting> thursdayMeetings = new ObservableCollection<IMeeting>();
      ObservableCollection<IMeeting> fridayMeetings = new ObservableCollection<IMeeting>();
      IMeetingViewModelWrapper mondayMeetingViewModelWrapper = new MeetingViewModelWrapper(mondayMeetings);
      IMeetingViewModelWrapper tuesdayMeetingViewModelWrapper = new MeetingViewModelWrapper(tuesdayMeetings);
      IMeetingViewModelWrapper wednesdayMeetingViewModelWrapper = new MeetingViewModelWrapper(wednesdayMeetings);
      IMeetingViewModelWrapper thursdayMeetingViewModelWrapper = new MeetingViewModelWrapper(thursdayMeetings);
      IMeetingViewModelWrapper fridayMeetingViewModelWrapper = new MeetingViewModelWrapper(fridayMeetings);

      ISchedulerDayViewModel mondayViewModel = new SchedulerDayViewModel("10", "Montag", mondayMeetingViewModelWrapper);
      ISchedulerDayViewModel tuesdayViewModel = new SchedulerDayViewModel("11", "Dienstag", tuesdayMeetingViewModelWrapper);
      ISchedulerDayViewModel wednesdayViewModel = new SchedulerDayViewModel("12", "Mittwoch", wednesdayMeetingViewModelWrapper);
      ISchedulerDayViewModel thursdayViewModel = new SchedulerDayViewModel("13", "Donnerstag", thursdayMeetingViewModelWrapper);
      ISchedulerDayViewModel fridayViewModel = new SchedulerDayViewModel("14", "Freitag", fridayMeetingViewModelWrapper);

      ISchedulerWeekViewModel schedulerWeekViewModel = new SchedulerWeekViewModel(
        mondayViewModel,
        tuesdayViewModel,
        wednesdayViewModel,
        thursdayViewModel,
        fridayViewModel);

      MainViewModel = new MainViewModel(schedulerWeekViewModel);
    }

    public IMainViewModel MainViewModel { get; }
  }
}