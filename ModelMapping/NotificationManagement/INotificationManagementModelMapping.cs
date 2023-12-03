using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.ModelMapping.NotificationManagement
{
    public interface INotificationManagementModelMapping
    {
        public Task<List<Notifications>> NotificationManagementMapping(List<object[]> array);
    }
}
