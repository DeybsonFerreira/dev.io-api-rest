
using System.Collections.Generic;

namespace app.Business.Notification
{
    public interface INotify
    {
        bool HasNotification();
        List<NotificationLite> Get();
        void Handle(NotificationLite notificacao);

    }
}