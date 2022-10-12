using System;
using System.Windows.Controls;

namespace NoteOrganizer.Views
{
  /// <summary>
  /// Interaktionslogik für SchedulerWeekView.xaml
  /// </summary>
  public partial class SchedulerWeekView : UserControl
  {
    public SchedulerWeekView()
    {
      InitializeComponent();
      DateTime now = DateTime.Now;
      ScrollView.ScrollToVerticalOffset(Math.Min(1600, Math.Max(0, now.Hour * 180 + now.Minute - 180)));
    }
  }
}