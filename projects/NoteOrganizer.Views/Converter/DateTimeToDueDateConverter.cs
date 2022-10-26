using NoteOrganizer.Resources;
using System;
using System.Globalization;
using System.Windows.Data;

namespace NoteOrganizer.Views.Converter
{
  internal class DateTimeToDueDateConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is DateOnly dateTime)
      {
        int dayDifference = dateTime.DayOfYear - DateTime.Now.DayOfYear;
        int weekDifference = GetIso8601WeekOfYear(dateTime.ToDateTime(TimeOnly.MinValue)) - GetIso8601WeekOfYear(DateTime.Now);
        int monthDifference = dateTime.Month - DateTime.Now.Month;
        int yearDifference = dateTime.Year - DateTime.Now.Year;
        if (dayDifference == 0)
          return $"{ResourceStrings_de.Due}: {ResourceStrings_de.Today}";
        if (dayDifference == 1)
          return $"{ResourceStrings_de.Due}: {ResourceStrings_de.Tomorrow}";
        if (weekDifference == 0)
          return $"{ResourceStrings_de.Due}: {ResourceStrings_de.ThisWeek}";
        if (weekDifference == 1)
          return $"{ResourceStrings_de.Due}: {ResourceStrings_de.NextWeek}";
        if (monthDifference == 0)
          return $"{ResourceStrings_de.Due}: {ResourceStrings_de.ThisMonth}";
        if (monthDifference == 1)
          return $"{ResourceStrings_de.Due}: {ResourceStrings_de.NextMonth}";
        if (yearDifference == 0)
          return $"{ResourceStrings_de.Due}: {ResourceStrings_de.ThisMonth}";
        if (yearDifference == 1)
          return $"{ResourceStrings_de.Due}: {ResourceStrings_de.NextYear}";
      }

      return $"{ResourceStrings_de.Due}: {ResourceStrings_de.Later}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
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