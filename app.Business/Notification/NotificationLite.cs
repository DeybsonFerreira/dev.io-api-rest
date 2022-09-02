namespace app.Business.Notification
{
    public class NotificationLite
    {
        public string Message { get; }
        public NotificationLite(string message)
        {
            Message = message;
        }
    }
}