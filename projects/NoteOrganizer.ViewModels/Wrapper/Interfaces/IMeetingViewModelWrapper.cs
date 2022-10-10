using NoteOrganizer.ViewModels.Interfaces;
using System.ComponentModel;

namespace NoteOrganizer.ViewModels.Wrapper.Interfaces
{
  public interface IMeetingViewModelWrapper : INotifyPropertyChanged
  {
    List<IMeetingViewModel> MeetingViewModels { get; }
  }
}