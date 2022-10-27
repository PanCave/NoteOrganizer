using NoteOrganizer.ViewModels.Interfaces;

namespace NoteOrganizer.ViewModels
{
  public class MainViewModel : IMainViewModel
  {
    public MainViewModel(ICombinedViewModel combinedViewModel)
    {
      CombinedViewModel = combinedViewModel;
    }

    public ICombinedViewModel CombinedViewModel { get; }
  }
}