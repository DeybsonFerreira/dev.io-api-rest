using System.Collections.Generic;
using System.Linq;

namespace app.Business.Notification
{
    public class Notify : INotify
    {
        protected List<NotificationLite> _notifications;

        public Notify()
        {
            _notifications = new List<NotificationLite>();
        }

        public void Handle(NotificationLite NotificationLite)
        {
            _notifications.Add(NotificationLite);
        }

        public List<NotificationLite> Get()
        {
            return _notifications;
        }

        public bool HasNotify()
        {
            return _notifications.Any();
        }
    }
}