using NoteOrganizer.BL;
using NoteOrganizer.BL.BO;
using NoteOrganizer.BL.Interfaces;
using NoteOrganizer.Persistence.Interfaces;
using NoteOrganizer.Persistence.Outlook;
using NoteOrganizer.Persistence.Outlook.Interfaces;
using NoteOrganizer.Resources;
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
      //outlookMeetingsLoader.LoadMeetings(startOfWeekTwoWeeksAgo, endOfWeekFourWeekFromNow, calendar);
      IMeetingToMeetingViewModelConverter meetingToMeetingViewModelConverter = new MeetingToMeetingViewModelConverter();

      IMeetingViewModelWrapper mondayMeetingViewModelWrapper = new MeetingViewModelWrapper(calendar[today.AddDays(1 - (int)dayOfWeek)], meetingToMeetingViewModelConverter);
      IMeetingViewModelWrapper tuesdayMeetingViewModelWrapper = new MeetingViewModelWrapper(calendar[today.AddDays(1 - (int)dayOfWeek + 1)], meetingToMeetingViewModelConverter);
      IMeetingViewModelWrapper wednesdayMeetingViewModelWrapper = new MeetingViewModelWrapper(calendar[today.AddDays(1 - (int)dayOfWeek + 2)], meetingToMeetingViewModelConverter);
      IMeetingViewModelWrapper thursdayMeetingViewModelWrapper = new MeetingViewModelWrapper(calendar[today.AddDays(1 - (int)dayOfWeek + 3)], meetingToMeetingViewModelConverter);
      IMeetingViewModelWrapper fridayMeetingViewModelWrapper = new MeetingViewModelWrapper(calendar[today.AddDays(1 - (int)dayOfWeek + 4)], meetingToMeetingViewModelConverter);

      ISchedulerDayHeaderViewModel mondayHeaderViewModel = new SchedulerDayHeaderViewModel("10", ResourceStrings_de.Monday);
      ISchedulerDayHeaderViewModel tuesdayHeaderViewModel = new SchedulerDayHeaderViewModel("11", ResourceStrings_de.Tuesday);
      ISchedulerDayHeaderViewModel wednesdayHeaderViewModel = new SchedulerDayHeaderViewModel("12", ResourceStrings_de.Wednesday);
      ISchedulerDayHeaderViewModel thursdayHeaderViewModel = new SchedulerDayHeaderViewModel("13", ResourceStrings_de.Thursday);
      ISchedulerDayHeaderViewModel fridayHeaderViewModel = new SchedulerDayHeaderViewModel("14", ResourceStrings_de.Friday);

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

      IAgenda agenda = new Agenda();
      agenda.AddTodo(new Todo("HottCAD", "Termine anlegen", today, new TimeOnly(16, 0, 0), DateTime.Today));
      agenda.AddTodo(new Todo("Energieberater", "Sprintplanungstermin teilen", today, new TimeOnly(16, 0, 0), DateTime.Today));
      agenda.AddTodo(new Todo("TÜV", "Termin nachfragen", today.AddDays(-2), new TimeOnly(16, 0, 0), DateTime.Today));
      agenda.AddTodo(new Todo("Winterreifen", "Termin festmachen", today.AddDays(1), new TimeOnly(16, 0, 0), DateTime.Today));
      agenda.AddTodo(new Todo("HNO", "Termin festmachen", today.AddDays(3), new TimeOnly(16, 0, 0), DateTime.Today));
      agenda.AddTodo(new Todo("Transporter holen", "Schlüssel bei Christine abholen", today.AddDays(15), new TimeOnly(16, 0, 0), DateTime.Today));
      agenda.AddTodo(new Todo("Bett abholen", "Bett aus Köln-Süd abholen", today.AddDays(16), new TimeOnly(16, 0, 0), DateTime.Today));

      ITodoToTodoViewModelConverter todoToTodoViewModelConverter = new TodoToTodoViewModelConverter();
      IDateOnlyToToTimeCategoryConverter dateOnlyToToTimeCategoryConverter = new DateOnlyToTimeCategoryConverter();
      ITodoListItemViewModelWrapper todoListItemViewModelWrapper = new TodoListItemViewModelWrapper(agenda, todoToTodoViewModelConverter, dateOnlyToToTimeCategoryConverter);

      ITodoListViewModel todoListViewModel = new TodoListViewModel(todoListItemViewModelWrapper.TodoListItemViewModels);

      ICombinedViewModel combinedViewModel = new CombinedViewModel(todoListViewModel, schedulerWeekViewModel);

      MainViewModel = new MainViewModel(combinedViewModel);
    }

    public IMainViewModel MainViewModel { get; }
  }
}