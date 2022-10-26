using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.ViewModels.Interfaces;

namespace NoteOrganizer.ViewModels.Converter.Interfaces
{
  public interface ITodoToTodoViewModelConverter
  {
    ITodoViewModel Convert(ITodo todo);
  }
}