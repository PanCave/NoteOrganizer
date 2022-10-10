using NoteOrganizer.BL.BO.Interfaces;
using System.Collections.ObjectModel;

namespace NoteOrganizer.BL.Interfaces
{
  public interface ICalendar
  {
    void AddMeeting(IMeeting meeting, DateOnly date);

    ObservableCollection<IMeeting> this[DateOnly date] { get; }
  }
}