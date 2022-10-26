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

    public DataTemplate SeparatorTemplate { get; set; }
    public DataTemplate TodoTemplate { get; set; }
  }
}