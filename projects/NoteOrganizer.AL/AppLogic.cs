using NoteOrganizer.BL;
using NoteOrganizer.BL.Interfaces;
using NoteOrganizer.Persistence.Interfaces;
using NoteOrganizer.Persistence.Outlook;
using NoteOrganizer.Persistence.Outlook.Interfaces;
using NoteOrganizer.Resources;
using NoteOrganizer.ViewModels;
using NoteOrganizer.ViewModels.Commands;
using NoteOrganizer.ViewModels.Converter;
using NoteOrganizer.ViewModels.Converter.Interfaces;
using NoteOrganizer.ViewModels.Interfaces;
using NoteOrganizer.ViewModels.Wrapper;
using NoteOrganizer.ViewModels.Wrapper.Interfaces;
using NoteOrganizer.Views;
using System.Windows;
using System.Windows.Input;

namespace NoteOrganizer.AL
{
  public class AppLogic
  {
    private readonly List<TimeOnly> dueTimes;
    private Window? createTodoWindow;

    public AppLogic()
    {
      dueTimes = new List<TimeOnly>();
      FillDueTimesList();

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

      ISchedulerDayHeaderViewModel mondayHeaderViewModel = new SchedulerDayHeaderViewModel(calendar[today.AddDays(1 - (int)dayOfWeek)].Date.Day.ToString(), ResourceStrings_de.Monday);
      ISchedulerDayHeaderViewModel tuesdayHeaderViewModel = new SchedulerDayHeaderViewModel(calendar[today.AddDays(1 - (int)dayOfWeek + 1)].Date.Day.ToString(), ResourceStrings_de.Tuesday);
      ISchedulerDayHeaderViewModel wednesdayHeaderViewModel = new SchedulerDayHeaderViewModel(calendar[today.AddDays(1 - (int)dayOfWeek + 2)].Date.Day.ToString(), ResourceStrings_de.Wednesday);
      ISchedulerDayHeaderViewModel thursdayHeaderViewModel = new SchedulerDayHeaderViewModel(calendar[today.AddDays(1 - (int)dayOfWeek + 3)].Date.Day.ToString(), ResourceStrings_de.Thursday);
      ISchedulerDayHeaderViewModel fridayHeaderViewModel = new SchedulerDayHeaderViewModel(calendar[today.AddDays(1 - (int)dayOfWeek + 4)].Date.Day.ToString(), ResourceStrings_de.Friday);

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

      ITodoWrapper todoWrapper = new TodoWrapper();

      ICommand saveTodoCommand = new SaveTodoCommand(todoWrapper, agenda, () => createTodoWindow?.Close());
      ICommand openCreateTodoWindowCommand = new OpenCreateTodoWindowCommand(() => OpenCreateTodoWindow(todoWrapper, saveTodoCommand));

      ITodoToTodoViewModelConverter todoToTodoViewModelConverter = new TodoToTodoViewModelConverter();
      IDateOnlyToToTimeCategoryConverter dateOnlyToToTimeCategoryConverter = new DateOnlyToTimeCategoryConverter();
      ITodoListItemViewModelWrapper todoListItemViewModelWrapper = new TodoListItemViewModelWrapper(agenda, todoToTodoViewModelConverter, dateOnlyToToTimeCategoryConverter);

      ITodoListViewModel todoListViewModel = new TodoListViewModel(todoListItemViewModelWrapper);

      IToolbarViewModel toolbarViewModel = new ToolbarViewModel(openCreateTodoWindowCommand);

      ICombinedViewModel combinedViewModel = new CombinedViewModel(toolbarViewModel, todoListViewModel, schedulerWeekViewModel);

      MainViewModel = new MainViewModel(combinedViewModel);
    }

    private void FillDueTimesList()
    {
      for (int i = 6; i < 19; i++)
      {
        dueTimes.Add(new TimeOnly(i, 0, 0));
      }
    }

    private void OpenCreateTodoWindow(ITodoWrapper todoWrapper, ICommand saveTodoCommand)
    {
      createTodoWindow = new Window();

      createTodoWindow.Height = 450;
      createTodoWindow.Width = 800;
      createTodoWindow.Title = ResourceStrings_de.CreateNewTodo;
      createTodoWindow.ResizeMode = ResizeMode.CanMinimize;

      createTodoWindow.DataContext = new CreateTodoViewModel(todoWrapper, dueTimes, saveTodoCommand);
      createTodoWindow.Content = new CreateTodoView();
      createTodoWindow.Show();
    }

    public IMainViewModel MainViewModel { get; }
  }
}