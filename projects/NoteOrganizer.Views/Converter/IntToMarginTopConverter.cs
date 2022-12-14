using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NoteOrganizer.Views.Converter
{
  internal class IntToMarginTopConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is int topMargin)
        return new Thickness(0, topMargin, 0, 0);
      return new Thickness(0);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is Thickness margin)
        return margin.Top;
      return 0;
    }
  }
}