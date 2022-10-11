using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace NoteOrganizer.BL.BO
{
  public class SupressableObservableCollection<T> : ObservableCollection<T>
  {
    private bool _notificationSupressed = false;
    private bool _supressNotification = false;

    public SupressableObservableCollection(List<T> list) : base(list)
    {
    }

    public SupressableObservableCollection() : base()
    {
    }

    public bool SupressNotification
    {
      get
      {
        return _supressNotification;
      }
      set
      {
        _supressNotification = value;
        if (_supressNotification == false && _notificationSupressed)
        {
          this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
          _notificationSupressed = false;
        }
      }
    }

    protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
      if (SupressNotification)
      {
        _notificationSupressed = true;
        return;
      }
      base.OnCollectionChanged(e);
    }
  }
}