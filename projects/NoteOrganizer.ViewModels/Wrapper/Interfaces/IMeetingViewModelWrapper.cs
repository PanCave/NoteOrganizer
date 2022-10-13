using NoteOrganizer.ViewModels.Interfaces;

namespace NoteOrganizer.ViewModels.Wrapper.Interfaces
{
  public interface IMeetingViewModelWrapper
  {
    List<IMeetingViewModel> MeetingViewModels { get; }
  }
}