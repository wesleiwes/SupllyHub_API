using SupllyHub.Business.Interfaces;

namespace SupllyHub.Business.Notifications;
public class Notifier : INotifier
{
    private readonly List<Notification> _notifications;

    public Notifier()
    {
        _notifications = [];
    }

    public List<Notification> GetNotifications() => _notifications;
    

    public void Handle(Notification notification) => _notifications.Add(notification);

    public bool HasNotification() => _notifications.Count != 0;
}
