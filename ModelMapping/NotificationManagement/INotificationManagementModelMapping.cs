using TechnicalTestAPI.Models.ServiceModels;

namespace TechnicalTestAPI.ModelMapping.NotificationManagement
{
    public interface INotificationManagementModelMapping
    {
        public Task<List<Notifications>> NotificationManagementMapping(List<object[]> array);
    }
}
