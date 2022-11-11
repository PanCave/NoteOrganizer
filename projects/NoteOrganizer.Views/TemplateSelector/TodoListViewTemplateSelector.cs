using NoteOrganizer.ViewModels.Converter;
using System.Windows;
using System.Windows.Controls;

namespace NoteOrganizer.Views.TemplateSelector
{
  internal class TodoListViewTemplateSelector : DataTemplateSelector
  {
    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
      return (item is TodoViewModel) ? TodoTemplate : SeparatorTemplate;
    }

#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
    public DataTemplate SeparatorTemplate { get; set; }
    public DataTemplate TodoTemplate { get; set; }
#pragma warning restore CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
  }
}