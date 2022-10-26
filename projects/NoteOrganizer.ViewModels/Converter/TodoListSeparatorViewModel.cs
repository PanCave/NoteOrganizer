using NoteOrganizer.Resources;
using NoteOrganizer.ViewModels.Interfaces;

namespace NoteOrganizer.ViewModels.Converter
{
  public class TodoListSeparatorViewModel : ITodoListItemViewModel
  {
    public TodoListSeparatorViewModel(TimeCategory timeCategory)
    {
      Title = CalculateTitleFromTimeCategory(timeCategory);
    }

    public string Title { get; }

    private string CalculateTitleFromTimeCategory(TimeCategory timeCategory)
    {
      switch (timeCategory)
      {
        case TimeCategory.Overdue:
          return ResourceStrings_de.Overdue;

        case TimeCategory.Today:
          return ResourceStrings_de.Today;

        case TimeCategory.Tomorrow:
          return ResourceStrings_de.Tomorrow;

        case TimeCategory.ThisWeek:
          return ResourceStrings_de.ThisWeek;

        case TimeCategory.NextWeek:
          return ResourceStrings_de.NextWeek;

        case TimeCategory.ThisMonth:
          return ResourceStrings_de.ThisMonth;

        case TimeCategory.NextMonth:
          return ResourceStrings_de.NextMonth;

        case TimeCategory.ThisYear:
          return ResourceStrings_de.ThisYear;

        case TimeCategory.NextYear:
          return ResourceStrings_de.NextYear;

        default:
        case TimeCategory.Later:
          return ResourceStrings_de.Later;
      }
    }
  }
}