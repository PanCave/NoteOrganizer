using NoteOrganizer.BL;
using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.BL.Interfaces;
using NoteOrganizer.Persistence.Interfaces;
using NoteOrganizer.Persistence.Outlook;
using NoteOrganizer.Persistence.Outlook.Interfaces;
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
      DateOnly today = DateOnly.FromDateTime(DateTime.Now);
      DayOfWeek dayOfWeek = today.DayOfWeek;
      DateOnly startOfWeekTwoWeeksAgo = today.AddDays(1 - (int)dayOfWeek - 14);
      DateOnly endOfWeekFourWeekFromNow = today.AddDays((5 - (int)dayOfWeek) + 28);

      IAppointmentItemToMeetingConverter appointmentItemToMeetingConverter = new AppointmentItemToMeetingConverter();
      IMeetingsLoader outlookMeetingsLoader = new OutlookMeetingLoader(appointmentItemToMeetingConverter);
      Dictionary<DateOnly, List<IMeeting>> meetingsDictionary = outlookMeetingsLoader.LoadMeetings(startOfWeekTwoWeeksAgo, endOfWeekFourWeekFromNow);

      ICalendar calendar = new Calendar();
      calendar.AddMeetingsfromDictionary(meetingsDictionary);

      ObservableCollection<IMeeting> mondayMeetings = calendar[today.AddDays(1 - (int)dayOfWeek)];
      ObservableCollection<IMeeting> tuesdayMeetings = calendar[today.AddDays(1 - (int)dayOfWeek + 1)];
      ObservableCollection<IMeeting> wednesdayMeetings = calendar[today.AddDays(1 - (int)dayOfWeek + 2)];
      ObservableCollection<IMeeting> thursdayMeetings = calendar[today.AddDays(1 - (int)dayOfWeek + 3)];
      ObservableCollection<IMeeting> fridayMeetings = calendar[today.AddDays(1 - (int)dayOfWeek + 4)];

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