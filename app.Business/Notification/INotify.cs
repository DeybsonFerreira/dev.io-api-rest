
using System.Collections.Generic;

namespace app.Business.Notification
{
    public interface INotify
    {
        bool HasNotify();
        List<NotificationLite> Get();
        void Handle(NotificationLite notificacao);

    }
}