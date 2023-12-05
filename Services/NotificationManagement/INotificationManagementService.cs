using TechnicalTestAPI.Models.ServiceModels;

namespace TechnicalTestAPI.Services.NotificationManagement
{
    public interface INotificationManagementService
    {
        public Task<dynamic> ReadNotifications();
        public Task<dynamic> CreateNotifications(Notifications notificationsInput);
        public Task<dynamic> UpdateNotifications(Notifications notificationsInput);
        public Task<dynamic> DeleteNotifications(Notifications notificationsInput);
    }
}
