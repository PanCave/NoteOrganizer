using NoteOrganizer.BL;
using NoteOrganizer.BL.Interfaces;
using NoteOrganizer.Persistence.Interfaces;
using NoteOrganizer.Persistence.Outlook;
using NoteOrganizer.Persistence.Outlook.Interfaces;
using NoteOrganizer.ViewModels;
using NoteOrganizer.ViewModels.Converter;
using NoteOrganizer.ViewModels.Converter.Interfaces;
using NoteOrganizer.ViewModels.Interfaces;
using NoteOrganizer.ViewModels.Wrapper;
using NoteOrganizer.ViewModels.Wrapper.Interfaces;

namespace NoteOrganizer.AL
{
  public class AppLogic
  {
    public AppLogic()
    {
      ICalendar calendar = new Calendar();

      DateOnly today = DateOnly.FromDateTime(DateTime.Now);
      DayOfWeek dayOfWeek = today.DayOfWeek;
      DateOnly startOfWeekTwoWeeksAgo = today.AddDays(1 - (int)dayOfWeek - 14);
      DateOnly endOfWeekFourWeekFromNow = today.AddDays((5 - (int)dayOfWeek) + 28);

      IAppointmentItemToMeetingConverter appointmentItemToMeetingConverter = new AppointmentItemToMeetingConverter();
      IMeetingsLoader outlookMeetingsLoader = new OutlookMeetingLoader(appointmentItemToMeetingConverter);
      outlookMeetingsLoader.LoadMeetings(startOfWeekTwoWeeksAgo, endOfWeekFourWeekFromNow, calendar);
      IMeetingToMeetingViewModelConverter meetingToMeetingViewModelConverter = new MeetingToMeetingViewModelConverter();

      IMeetingViewModelWrapper mondayMeetingViewModelWrapper = new MeetingViewModelWrapper(calendar[today.AddDays(1 - (int)dayOfWeek)], meetingToMeetingViewModelConverter);
      IMeetingViewModelWrapper tuesdayMeetingViewModelWrapper = new MeetingViewModelWrapper(calendar[today.AddDays(1 - (int)dayOfWeek + 1)], meetingToMeetingViewModelConverter);
      IMeetingViewModelWrapper wednesdayMeetingViewModelWrapper = new MeetingViewModelWrapper(calendar[today.AddDays(1 - (int)dayOfWeek + 2)], meetingToMeetingViewModelConverter);
      IMeetingViewModelWrapper thursdayMeetingViewModelWrapper = new MeetingViewModelWrapper(calendar[today.AddDays(1 - (int)dayOfWeek + 3)], meetingToMeetingViewModelConverter);
      IMeetingViewModelWrapper fridayMeetingViewModelWrapper = new MeetingViewModelWrapper(calendar[today.AddDays(1 - (int)dayOfWeek + 4)], meetingToMeetingViewModelConverter);

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