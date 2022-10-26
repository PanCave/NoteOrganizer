using NoteOrganizer.BL.BO.Interfaces;

namespace NoteOrganizer.BL.Interfaces
{
  public interface IAgenda
  {
    void AddTodo(ITodo todo);

    ITodo[] Todos { get; }
  }
}