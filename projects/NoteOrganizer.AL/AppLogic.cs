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

      ISchedulerDayHeaderViewModel mondayHeaderViewModel = new SchedulerDayHeaderViewModel("10", "Montag");
      ISchedulerDayHeaderViewModel tuesdayHeaderViewModel = new SchedulerDayHeaderViewModel("11", "Dienstag");
      ISchedulerDayHeaderViewModel wednesdayHeaderViewModel = new SchedulerDayHeaderViewModel("12", "Mittwoch");
      ISchedulerDayHeaderViewModel thursdayHeaderViewModel = new SchedulerDayHeaderViewModel("13", "Donnerstag");
      ISchedulerDayHeaderViewModel fridayHeaderViewModel = new SchedulerDayHeaderViewModel("14", "Freitag");

      ISchedulerDayViewModel mondayViewModel = new SchedulerDayViewModel(mondayMeetingViewModelWrapper);
      ISchedulerDayViewModel tuesdayViewModel = new SchedulerDayViewModel(tuesdayMeetingViewModelWrapper);
      ISchedulerDayViewModel wednesdayViewModel = new SchedulerDayViewModel(wednesdayMeetingViewModelWrapper);
      ISchedulerDayViewModel thursdayViewModel = new SchedulerDayViewModel(thursdayMeetingViewModelWrapper);
      ISchedulerDayViewModel fridayViewModel = new SchedulerDayViewModel(fridayMeetingViewModelWrapper);

      ISchedulerWeekViewModel schedulerWeekViewModel = new SchedulerWeekViewModel(
        mondayHeaderViewModel,
        tuesdayHeaderViewModel,
        wednesdayHeaderViewModel,
        thursdayHeaderViewModel,
        fridayHeaderViewModel,
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