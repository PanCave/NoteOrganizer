using Microsoft.Office.Interop.Outlook;
using NoteOrganizer.BL.BO.Interfaces;
using NoteOrganizer.Persistence.Interfaces;
using NoteOrganizer.Persistence.Outlook.Interfaces;

namespace NoteOrganizer.Persistence.Outlook
{
  public class OutlookMeetingLoader : IMeetingsLoader
  {
    private readonly IAppointmentItemToMeetingConverter appointmentItemToMeetingConverter;
    private Application? oApp;
    private NameSpace? mapiNamespace;
    private MAPIFolder? CalendarFolder;
    private Items? outlookCalendarItems;

    public OutlookMeetingLoader(IAppointmentItemToMeetingConverter appointmentItemToMeetingConverter)
    {
      this.appointmentItemToMeetingConverter = appointmentItemToMeetingConverter;
    }

    public Dictionary<DateOnly, List<IMeeting>> LoadMeetings(DateOnly startDate, DateOnly endDate)
    {
      Dictionary<DateOnly, List<IMeeting>> meetingslistDictionary = new Dictionary<DateOnly, List<IMeeting>>();

      oApp = new Application();
      mapiNamespace = oApp.GetNamespace("MAPI");
      CalendarFolder = mapiNamespace.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
      outlookCalendarItems = CalendarFolder.Items;
      outlookCalendarItems.IncludeRecurrences = true;
      Items filteredItems = outlookCalendarItems.Restrict("( [Start] >= '" + startDate.ToString("MM/dd/yyyy") + "'" + " AND " + "  [End]  < '" + endDate.ToString("MM/dd/yyyy") + "' )");

      foreach (AppointmentItem item in filteredItems)
      {
        if (item.IsRecurring)
        {
          RecurrencePattern rp = item.GetRecurrencePattern();
          DateTime first = new DateTime(startDate.Year, startDate.Month, startDate.Day, item.Start.Hour, item.Start.Minute, 0);
          DateTime last = endDate.ToDateTime(new TimeOnly(0, 0, 0));
          AppointmentItem recur;

          for (DateTime cur = first; cur <= last; cur = cur.AddDays(1))
          {
            try
            {
              recur = rp.GetOccurrence(cur);
              //Console.WriteLine(recur.Subject + " -> " + cur.ToLongDateString());
              AddAppointmentItemToDictionary(recur, meetingslistDictionary);
            }
            catch
            { }
          }
        }
        else
        {
          DateTime first = startDate.ToDateTime(new TimeOnly(0, 0, 0));
          DateTime last = endDate.ToDateTime(new TimeOnly(23, 59, 59));
          if (item.Start > first && item.Start < last)
            AddAppointmentItemToDictionary(item, meetingslistDictionary);
          //Console.WriteLine(item.Subject + " -> " + item.Start.ToLongDateString());
        }
      }

      return meetingslistDictionary;
    }

    private void AddAppointmentItemToDictionary(AppointmentItem appointmentItem, Dictionary<DateOnly, List<IMeeting>> dictionary)
    {
      IMeeting meeting = appointmentItemToMeetingConverter.Convert(appointmentItem);
      DateOnly date = DateOnly.FromDateTime(appointmentItem.Start);
      if (!dictionary.ContainsKey(date))
      {
        List<IMeeting> meetings = new List<IMeeting>();
        meetings.Add(meeting);
        dictionary.Add(date, meetings);
      }
      else
      {
        int i = 0;
        bool inserted = false;
        foreach (IMeeting m in dictionary[date])
        {
          if (m.StartTime > meeting.StartTime)
          {
            dictionary[date].Insert(i, meeting);
            inserted = true;
            break;
          }
          i++;
        }
        if (!inserted)
          dictionary[date].Add(meeting);
      }
    }
  }
}