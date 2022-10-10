using NoteOrganizer.AL;
using System.Windows;

namespace NoteOrganizer
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      AppLogic appLogic = new AppLogic();
      DataContext = appLogic.MainViewModel;
    }
  }
}