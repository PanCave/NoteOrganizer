using NoteOrganizer.ViewModels.Converter.Interfaces;
using NoteOrganizer.ViewModels.Interfaces;
using System.Globalization;

namespace NoteOrganizer.ViewModels.Converter
{
  public class DateOnlyToTimeCategoryConverter : IDateOnlyToToTimeCategoryConverter
  {
    public TimeCategory ConvertToTimeCategory(DateOnly date)
    {
      int dayDifference = date.DayOfYear - DateTime.Now.DayOfYear;
      int weekDifference = GetIso8601WeekOfYear(date.ToDateTime(TimeOnly.MinValue)) - GetIso8601WeekOfYear(DateTime.Now);
      int monthDifference = date.Month - DateTime.Now.Month;
      int yearDifference = date.Year - DateTime.Now.Year;
      if (dayDifference < 0)
        return TimeCategory.Overdue;
      if (dayDifference == 0)
        return TimeCategory.Today;
      if (dayDifference == 1)
        return TimeCategory.Tomorrow;
      if (dayDifference == 2)
        return TimeCategory.TheDayAfterTomorrow;
      if (weekDifference == 0)
        return TimeCategory.ThisWeek;
      if (weekDifference == 1)
        return TimeCategory.NextWeek;
      if (monthDifference == 0)
        return TimeCategory.ThisMonth;
      if (monthDifference == 1)
        return TimeCategory.NextMonth;
      if (yearDifference == 0)
        return TimeCategory.ThisMonth;
      if (yearDifference == 1)
        return TimeCategory.NextYear;

      return TimeCategory.Later;
    }

    private int GetIso8601WeekOfYear(DateTime time)
    {
      // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll
      // be the same week# as whatever Thursday, Friday or Saturday are,
      // and we always get those right
      DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
      if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
      {
        time = time.AddDays(3);
      }

      // Return the week of our adjusted day
      return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }
  }
}