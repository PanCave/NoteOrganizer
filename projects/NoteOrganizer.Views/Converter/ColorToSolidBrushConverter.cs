using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Color = NoteOrganizer.ViewModels.Wrapper.Interfaces.Color;

namespace NoteOrganizer.Views.Converter
{
  internal class ColorToSolidBrushConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value is Color color)
      {
        switch (color)
        {
          case Color.LightBlue:
            return new SolidColorBrush(Colors.BlueViolet);

          case Color.DarkBlue:
            return new SolidColorBrush(Colors.DarkBlue);

          case Color.LightRed:
            return new SolidColorBrush(Colors.IndianRed);

          case Color.DarkRed:
            return new SolidColorBrush(Colors.DarkRed);

          case Color.Orange:
            return new SolidColorBrush(Colors.Orange);

          case Color.Yellow:
            return new SolidColorBrush(Colors.DarkOrange);

          case Color.Purple:
            return new SolidColorBrush(Colors.Purple);

          case Color.Green:
            return new SolidColorBrush(Colors.DarkOliveGreen);

          default:
            return new SolidColorBrush(Colors.Gray);
        }
      }
      return new SolidColorBrush(Colors.DarkOrchid);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}