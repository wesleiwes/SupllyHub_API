using SupllyHub.Business.Notifications;

namespace SupllyHub.Business.Interfaces;
public interface INotifier
{
    bool HasNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notification);
}