using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.ModelMapping.DeviceManagement
{
    public class DeviceManagementModelMapping : IDeviceManagementModelMapping
    {
        public async Task<List<Devices>> DeviceManagementMapping(List<object[]> array)
        {
            var outputList = new List<Devices>();
            foreach (var item in array)
            {
                var output = new Devices
                {
                    deviceId = item[0].ToString(),
                    deviceName = item[1].ToString(),
                    deviceType = item[2].ToString(),
                    deviceOs = item[3].ToString(),
                    userId = item[4].ToString(),
                    userName = item[5].ToString(),
                    lastAccessedDate = item[6].ToString(),
                    lastAccessedTime = item[7].ToString()
                };
                outputList.Add(output);
            }
            return outputList;
        }
    }
}
