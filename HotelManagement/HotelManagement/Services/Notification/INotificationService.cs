using System;

namespace HotelManagement.Reception.Services.Notification
{
    public interface INotificationService
    {
        void Exception(
            Exception ex,
            string areaName = "WindowArea", TimeSpan? expirationTime = default(TimeSpan?), Action onClick = null, Action onClose = null);

        void Info(
            string title,
            string message,
            string areaName = "WindowArea", TimeSpan? expirationTime = default(TimeSpan?), Action onClick = null, Action onClose = null);

        void Warning(
            string title,
            string message,
            string areaName = "WindowArea", TimeSpan? expirationTime = default(TimeSpan?), Action onClick = null, Action onClose = null);

        void Success(
            string title,
            string message,
            string areaName = "WindowArea", TimeSpan? expirationTime = default(TimeSpan?), Action onClick = null, Action onClose = null);
    }
}
