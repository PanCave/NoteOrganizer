using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.ViewModels.Interfaces;

namespace NoteOrganizer.ViewModels.Converter.Interfaces
{
  public interface IMeetingToMeetingViewModelConverter
  {
    IMeetingViewModel Convert(IMeeting meeting, TimeOnly lastEndTime);
  }
}