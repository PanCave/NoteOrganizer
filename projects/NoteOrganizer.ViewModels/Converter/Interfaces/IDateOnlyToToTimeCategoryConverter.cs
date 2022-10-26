using NoteOrganizer.ViewModels.Interfaces;

namespace NoteOrganizer.ViewModels.Converter.Interfaces
{
  public interface IDateOnlyToToTimeCategoryConverter
  {
    TimeCategory ConvertToTimeCategory(DateOnly date);
  }
}