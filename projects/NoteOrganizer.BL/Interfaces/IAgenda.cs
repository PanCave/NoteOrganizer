using NoteOrganizer.BL.BO.Interfaces;
using System.ComponentModel;

namespace NoteOrganizer.BL.Interfaces
{
  public interface IAgenda : INotifyPropertyChanged
  {
    void AddTodo(ITodo todo);

    ITodo[] Todos { get; }
  }
}