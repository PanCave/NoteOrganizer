using NoteOrganizer.BL.BO;
using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.BL.Interfaces;

namespace NoteOrganizer.BL
{
  public class Calendar : ICalendar
  {
    private readonly Dictionary<DateOnly, ICalendarDay> calendarDaysDictionary;

    public Calendar()
    {
      calendarDaysDictionary = new();
    }

    public ICalendarDay this[DateOnly date] => GetCalendarDay(date);

    public void AddMeeting(IMeeting meeting, DateOnly date)
    {
      GetCalendarDay(date).AddMeeting(meeting);
    }

    private ICalendarDay GetCalendarDay(DateOnly date)
    {
      if (!calendarDaysDictionary.ContainsKey(date))
        calendarDaysDictionary[date] = new CalendarDay(date);
      return calendarDaysDictionary[date];
    }
  }
}