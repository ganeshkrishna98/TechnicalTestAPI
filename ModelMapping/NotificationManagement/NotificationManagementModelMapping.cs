using TechnicalTestAPI.Models.ServiceModels;

namespace TechnicalTestAPI.ModelMapping.NotificationManagement
{
    public class NotificationManagementModelMapping : INotificationManagementModelMapping
    {
        public async Task<List<Notifications>> NotificationManagementMapping(List<object[]> array)
        {
            var outputList = new List<Notifications>();
            foreach (var item in array)
            {
                var output = new Notifications
                {
                    notificationId = item[0].ToString(),
                    notificationName = item[1].ToString(),
                    notificationContent = item[2].ToString(),
                    createdDate = item[3].ToString(),
                    createdTime = item[4].ToString(),
                    createdUserId = item[5].ToString(),
                    createdUserName = item[6].ToString()
                };
                outputList.Add(output);
            }
            return outputList;
        }
    }
}
