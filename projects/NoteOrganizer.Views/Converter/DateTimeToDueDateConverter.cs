using NoteOrganizer.Resources;
using NoteOrganizer.ViewModels.Converter;
using NoteOrganizer.ViewModels.Converter.Interfaces;
using NoteOrganizer.ViewModels.Interfaces;
using System;
using System.Globalization;
using System.Windows.Data;

namespace NoteOrganizer.Views.Converter
{
  internal class DateTimeToDueDateConverter : IValueConverter
  {
    private readonly IDateOnlyToToTimeCategoryConverter dateOnlyToTimeCategoryConverter;

    public DateTimeToDueDateConverter()
    {
      dateOnlyToTimeCategoryConverter = new DateOnlyToTimeCategoryConverter();
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is DateOnly date)
      {
        TimeCategory timeCategory = dateOnlyToTimeCategoryConverter.ConvertToTimeCategory(date);
        switch (timeCategory)
        {
          case TimeCategory.Overdue:
            return $"{ResourceStrings_de.Overdue}!";

          case TimeCategory.Today:
            return $"{ResourceStrings_de.Due}: {ResourceStrings_de.Today}";

          case TimeCategory.Tomorrow:
            return $"{ResourceStrings_de.Due}: {ResourceStrings_de.Tomorrow}";

          case TimeCategory.ThisWeek:
            return $"{ResourceStrings_de.Due}: {ResourceStrings_de.ThisWeek}";

          case TimeCategory.NextWeek:
            return $"{ResourceStrings_de.Due}: {ResourceStrings_de.NextWeek}";

          case TimeCategory.ThisMonth:
            return $"{ResourceStrings_de.Due}: {ResourceStrings_de.ThisMonth}";

          case TimeCategory.NextMonth:
            return $"{ResourceStrings_de.Due}: {ResourceStrings_de.NextMonth}";

          case TimeCategory.ThisYear:
            return $"{ResourceStrings_de.Due}: {ResourceStrings_de.ThisYear}";

          case TimeCategory.NextYear:
            return $"{ResourceStrings_de.Due}: {ResourceStrings_de.NextYear}";

          default:
          case TimeCategory.Later:
            return $"{ResourceStrings_de.Due}: {ResourceStrings_de.Later}";
        }
      }

      return $"{ResourceStrings_de.Due}: {ResourceStrings_de.Later}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}