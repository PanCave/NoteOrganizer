using NoteOrganizer.ViewModels.Interfaces;

namespace NoteOrganizer.ViewModels
{
  public class SchedulerDayHeaderViewModel : ISchedulerDayHeaderViewModel
  {
    public SchedulerDayHeaderViewModel(string dayOfMonth, string weekday)
    {
      DayOfMonth = dayOfMonth;
      Weekday = weekday;
    }

    public string DayOfMonth { get; }
    public string Weekday { get; }
  }
}