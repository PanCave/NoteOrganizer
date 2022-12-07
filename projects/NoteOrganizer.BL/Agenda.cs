using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.BL.Interfaces;
using System.ComponentModel;

namespace NoteOrganizer.BL
{
  public class Agenda : IAgenda
  {
    private readonly List<ITodo> todos;
    private ITodo[] todoArray;

    public Agenda()
    {
      todos = new List<ITodo>();
      todoArray = new ITodo[0];
    }

    public void AddTodo(ITodo newTodo)
    {
      int i = 0;
      bool inserted = false;
      foreach (ITodo todo in todos)
      {
        if (todo.DueDate > newTodo.DueDate
          || (todo.DueDate == newTodo.DueDate && todo.DueTime > newTodo.DueTime))
        {
          todos.Insert(i, newTodo);
          inserted = true;
          break;
        }
        i++;
      }
      if (!inserted)
        todos.Add(newTodo);
      todoArray = this.todos.ToArray();
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Todos)));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public ITodo[] Todos => todoArray;
  }
}