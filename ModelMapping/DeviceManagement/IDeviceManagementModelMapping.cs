using UniversityOfNottinghamAPI.Models.ServiceModels;

namespace UniversityOfNottinghamAPI.ModelMapping.DeviceManagement
{
    public interface IDeviceManagementModelMapping
    {
        public Task<List<Devices>> DeviceManagementMapping(List<object[]> array);
    }
}
